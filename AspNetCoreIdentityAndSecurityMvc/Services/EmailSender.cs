﻿using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace AspNetCoreIdentityAndSecurityMvc.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<SmtpOptions> _options;

        public EmailSender(IOptions<SmtpOptions> options)
        {
            _options = options;
        }

        public async Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message)
        {
            var mailMessage = new MailMessage(fromAddress, toAddress, subject, message);

            var client = new SmtpClient(_options.Value.Host, _options.Value.Port)
            {
                Credentials = new NetworkCredential(_options.Value.Username, _options.Value.Password),
            };
            await client.SendMailAsync(mailMessage);
        }
    }
}
