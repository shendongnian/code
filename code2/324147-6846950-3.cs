    public DefaultLogger : IMyLogger
    {
        public void TraceWriteLine(string message)
        {
            HttpContext.Current.Trace.WriteLine(message);
        }
    }
