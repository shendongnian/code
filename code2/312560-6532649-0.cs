    public class MockEmailSender : IEmailSender
    {
        public int SendCount = 0;
        public void SendMail(...)
        {
            SendCount++;
        }
        // ... other IEmailSender methods ...
    }
