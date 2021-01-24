    public class EmailSender : IEmailSender
    {
        private readonly IMailService mailService;
        public EmailSender(IMailService mailService)
        {
            this.mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.Run(() => mailService.Send(new string[] { email }, subject, htmlMessage));
        }
    }
