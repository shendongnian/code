    public class FileLog : ILog
    {
        public void Log(string text)
        {
            // write text to a file
        }
    }
    public class DatabaseLog : ILog
    {
        public void Log(string text)
        {
            // write text to the database
        }
    }
    public interface ILog
    {
        void Log(string text);
    }
    public class SomeOtherClass
    {
        private ILog _logger;
        public SomeOtherClass(ILog logger)
        {
            // I don't know if logger is the FileLog or DatabaseLog
            // but I don't need to know either as long as its implementing ILog
            this._logger = logger;
            logger.Log("Hello World!");
        }    
    }
