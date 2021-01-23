    public static class IntExtensions
    {
        public static TimeSpan Seconds(this int value)
        {
            return new TimeSpan(0, 0, value);
        }
    }
    Thread.Sleep(3.Seconds());
