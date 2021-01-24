    public class EmailSender : IEmailSender
    {
        // Our private configuration variables
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;
        // Get our parameterized configuration
        public EmailSender(IConfiguration config)
        {
            this.host = config["EmailSender:Host"],
            this.port = config.GetValue<int>("EmailSender:Port"),
            this.enableSSL = config.GetValue<bool>("EmailSender:EnableSSL"),
            this.userName = config["EmailSender:UserName"],
            this.password = config["EmailSender:Password"]                                   
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSSL
            };
            return client.SendMailAsync(
                new MailMessage(userName, email, subject, message) { IsBodyHtml = true }
            );
        }
    }
