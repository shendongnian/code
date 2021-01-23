    public class Loggable<T> where T : Loggable<T>
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(T));
        protected static ILog Log
        {
            get
            {
                return log;
            }
        }
    }
