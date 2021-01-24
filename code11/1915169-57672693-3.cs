    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now() 
        {
            return Datetime.Now;
        }
    }
