    public class TransientA
    {
        public SingletonC SingletonC { get; set; }
        public ILogger Logger { get; set; }
    }
    public class TransientB
    {
        public SingletonC SingletonC { get; set; }
        public ILogger Logger { get; set; }
    }
    public class SingletonC
    {
        public ILogger Logger { get; set; }
    }
