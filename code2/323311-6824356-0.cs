    public class NotifyCustomerEmail
    {
        private void MailMessage { get; set; }
        public void SendAsyncOnceTransactionCommits()
        {
            if (MailMessage == null)
                ComposeMailMessage();
            NHibernateSessionManager
                .CurrentSession
                .Transaction
                .RegisterSynchronization(new SendEmailSynchronization(this.MailMessage));
        }
    }
