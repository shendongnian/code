    class Program
    {
        static void Main(string[] args)
        {
            Logger.Current = new Logger("Test Printer");
            Logger.Current.Print("hello from main");
            var t1 = Task.Run(() => { Logger.Current.Print("hello from thread " + Thread.CurrentThread.ManagedThreadId); });
            var t2 = Task.Run(() => { Logger.Current.Print("hello from thread " + Thread.CurrentThread.ManagedThreadId); });
            Task.WaitAll(t1, t2);
        }
    }
    class Logger
    {
        private string LogName;
        public Logger(string logName)
        {
            if (logName == null)
                throw new InvalidOperationException();
            this.LogName = logName;
        }
        public void Print(string text)
        {
            Console.WriteLine(LogName + ": " + text);
        }
        public static Logger Current
        {
            get
            {
                return CallContext.LogicalGetData("PrinterName") as Logger;
            }
            set
            {
                CallContext.LogicalSetData("PrinterName", value);
            }
        }
    }
