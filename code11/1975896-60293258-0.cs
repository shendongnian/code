    public class BasePlay
    {
        public DateTimeOffset StartTime { get; set; }
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
    }
    public class JumpBallPlay : BasePlay
    {
        public string ExtraProperty1 { get; set; }
    }
    public class FieldGoalAttemptPlay : BasePlay
    {
        public string ExtraProperty2 { get; set; }
    }
