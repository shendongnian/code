    public class FakeSystemClock : ISystemClock
    {
        // Note the setter.
        public DateTime Now { get; set; }
    }
    
