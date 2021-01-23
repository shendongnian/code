    public class Logger
    {
        static Logger()
        {
            this.Instance - new Logger();
        }
 
        public static Logger Instance
        {
            get;
            private set;
        }
        // Other non-static members
    }
