    class Program
    {
        static async void Main(string[] args)
        {
            Logger.Current = new Logger("Test Printer");
            Logger.Current.Print("hello from main");
            await Task.Run(() => Logger.Current.Print($"hello from thread {Thread.CurrentThread.ManagedThreadId}"));
            await Task.Run(() => Logger.Current.Print($"hello from thread {Thread.CurrentThread.ManagedThreadId}"));
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
        private static AsyncLocal<Logger> _logger = new AsyncLocal<Logger>();
        public static Logger Current
        {
            get => _logger.Value;
            set => _logger.Value = value;
            }
        }
    }
