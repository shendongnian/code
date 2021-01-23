    public interface IEmailFormatter
    {
        string Format(CompletedItem completedItem);
    }
    public class EmailNotificationService
    {
        public EmailNotificationService(IEmailFormatter formatter)
        {
        }
    }
