     public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = "send grid api key";
            //it looks like this  :
            // var apiKey = "SG.2MpCzyTvIQ.WhHMg6-VBjuqbn9k-8P9m6X9cHM73fk2fzAT5sA4zKc"; 
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress($"noreply@domaimName.com", "Email title");
            var to = new EmailAddress(email, email);
            var plainTextContent = htmlMessage;
            var htmlContent = htmlMessage;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            try
            {
                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //return Task.CompletedTask;
        }
    }
