    class Logger
    {
        private static Logger log = null;
        private void Logger()
        {
            setLevel(Logger.INFO);
        }
        public static Logger getLog()
        {
            if (log == null)
            {
                log = new Logger();
            }
            return log;
        }
    }
