    public class EmailSender : IEmailSender {
        private readonly IEmailConfiguration emailConfiguration;
        private readonly ILogger<EmailSender> logger;
        public EmailSender(IEmailConfiguration emailConfiguration, ILogger<EmailSender> logger) {
            this.emailConfiguration = emailConfiguration;
            this.logger = logger;
        }
        public Task SendEmailAsync(string recipientEmail, string subject, string message) {
            //...
        }
        //...
    }
