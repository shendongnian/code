    public class MultipleSourcesEmailService : IEmailService
    {
        private IEnumerable<IDatabaseSource> databases;
        public EmailService(params IDatabaseSource[] sources)
        {
            databases = new List<IDatabaseSource>(sources);        
        }
       
        public void SendEmailsToValidAddresses()
        {
            foreach(var database in databases)
            {
                var emailAddresses = database.SelectAllEmailAddresses();
                ValidateAndSendEmailsTo(emailAddresses);
            }
        }
        public void ValidateAndSendEmailsTo(IEnumerable<string> emailAddresses)
        {
            // Perform appropriate logic
            ...
        }
    }        
