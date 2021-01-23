    public interface IMonitor
    {
        void Start();
        bool IsStarted { get; }
    }
    public interface IProcessor
    {
        void Start();
        bool IsStarted { get; }
    }
    public class Operator : IMonitor, IProcessor
    {
        #region IMonitor Members
        bool _MonitorStarted;
        void IMonitor.Start()
        {
            Console.WriteLine("IMonitor.Start");
            _MonitorStarted = true;
        }
        bool IMonitor.IsStarted
        {
            get { return _MonitorStarted; }
        }
        #endregion
        #region IProcessor Members
        bool _ProcessorStarted;
        void IProcessor.Start()
        {
            Console.WriteLine("IProcessor.Start");
            _ProcessorStarted = true;
        }
        bool IProcessor.IsStarted
        {
            get { return _ProcessorStarted; }
        }
        #endregion
    }
    public class ClassBase<T>
        where T : IProcessor
    {
        protected T Inner { get; private set; }
        public ClassBase(T inner)
        {
            this.Inner = inner;
        }
        public void Start()
        {
            this.Inner.Start();
        }
    }
    public class MyClass<T> : ClassBase<T>
        //where T : IProcessor
    {
        public MyClass(T inner) : base(inner) { }
        public bool Check()
        {
            // this code was written assuming that it is calling IProcessor.IsStarted
            return this.Inner.IsStarted;
        }
    }
    public static class Extensions
    {
        public static void StartMonitoring(this IMonitor monitor)
        {
            monitor.Start();
        }
        public static void StartProcessing(this IProcessor processor)
        {
            processor.Start();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var @operator = new Operator();
            @operator.StartMonitoring();
            var myClass = new MyClass<Operator>(@operator);
            var result = myClass.Check();
            // the value of result will be false if the type constraint on T in ClassBase<T> is where T : IProcessor
            // the value of result will be true if the type constraint on T in ClassBase<T> is where T : IMonitor
        }
    }
