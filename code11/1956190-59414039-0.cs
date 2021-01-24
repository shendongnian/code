    public interface IConstants
    {
        string Name { get; }
        double InitialHealth { get; }
        public int? MaxTries { get; }
    }
    public class Thing1 : IConstants
    {
        public string Name => "Thing 1";
        public double InitialHealth => 100.0;
        public int? MaxTries => null;
    }
    public class Thing2 : IConstants
    {
        public string Name => "Thing 2";
        public double InitialHealth => 80.0;
        public int? MaxTries => 10;
    }
