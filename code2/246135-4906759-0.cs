    public interface IClock
    {
        DateTime Now { get; }
    }
    public class FakeClock : IClock
    {
        DateTime Now { get; set; }
    }
    public class SystemClock : IClock
    {
        DateTime Now { get { return DateTime.Now; } }
    }
