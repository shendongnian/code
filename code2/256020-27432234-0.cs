        protected void GetCurrentClassLogger()
        {
            //This should take you back to the previous frame and context of the Log call
            StackTrace trace = new StackTrace();
            if (trace.FrameCount > 1)
            {
                logger = LogManager.GetLogger(trace.GetFrame(1).GetMethod().ReflectedType.FullName);
            }
            else //This would go back to the stated problem
            {
                logger = LogManager.GetCurrentClassLogger();
            }
        }
        private void Write(LogLevel level, string format, params object[] args)
        {
            //added code
            GetCurrentClassLogger();
            LogEventInfo le = new LogEventInfo(level, logger.Name, null, format, args);
            logger.Log(typeof(NLogLogger), le);
        }
