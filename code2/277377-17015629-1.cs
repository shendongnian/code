    public interface IDateTimeUtcNowProvider
    {
        DateTime UtcNow { get; } 
    }
    public class DateTimeUtcNowProvider : IDateTimeUtcNowProvider
    {
        public DateTime UtcNow { get { return DateTime.UtcNow; } }
    }
