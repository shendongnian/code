    public class EmailSender : IEmailSender
    {
        private IMailService _mailService;
        public EmailSender(IMailService mailService)
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await Task.Run(() => _mailService.Send(new string[] { email }, subject, htmlMessage));
        }
    }
