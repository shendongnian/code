    public interface ILogger : IPlugin
    {
        void Log(string message);
    }
    [Export(typeof(ILogger))]
    public class ConsoleLogger : ILogger
    {
        void IPlugin.Initialise()
        {
            Console.WriteLine("Initialising plugin...");
        }
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Console.WriteLine("Disposing plugin...");
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
   
