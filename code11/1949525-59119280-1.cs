    public class EmailSender : IEmailSender {
        private readonly EmailSettings _emailSettings;
    
        public EmailSender( IOptions<EmailSettings> emailSettings) {
            _emailSettings = emailSettings.Value;
        }
        //...
    }
