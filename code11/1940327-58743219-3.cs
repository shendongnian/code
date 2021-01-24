    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;
        public EmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
          
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var from = _smtpSettings.FromAddress;
            //other logic
            using (var client = new SmtpClient())
            {
                {
                    await client.ConnectAsync(smtpSettings.Server, smtpSettings.Port, true);
                }
            }
            return Task.CompletedTask;
        }
    }
