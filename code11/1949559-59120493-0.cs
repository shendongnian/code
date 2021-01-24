    public class ApplicationTime
    {
        private readonly int _offset;
        public DateTime Now => System.DateTime.UtcNow.AddHours(offset);
        public ApplicationTime(int hoursOffset) => _offset = hoursOffset;
    }
