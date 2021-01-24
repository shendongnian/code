    public interface IStringProvider
    {
        string TheString { get; }
    }
    public class First : IStringProvider
    {
        public static readonly First Instance = new First();
        private First() {} // Make constructor private, so no one else can instantiate.
        public string TheString => "some text";
    }
    public class Second : IStringProvider
    {
        public static readonly First Instance = new Second();
        private Second() {}
        public string TheString => "another text";
    }
