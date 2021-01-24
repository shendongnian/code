    public class EmailSender : IEmailSender {
        private readonly EmailSettings emailSettings;
    
        public EmailSender(IOptions<EmailSettings> emailSettings) {
            this.emailSettings = emailSettings.Value;
        }
        //...
    }
