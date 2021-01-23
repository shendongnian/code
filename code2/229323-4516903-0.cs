    public void CatchError(Exception ex)
    {
        StackFrame parentFrame = new StackFrame(1);
        MethodBase mi = parentFrame.GetMethod();
        LoggingAttribute attr = mi.GetCustomAttributes(typeof(LoggingAttribute), true).FirstOrDefault() as LoggingAttribute;
        if (attr != null)
        {
           // do your logging.
        }
    }
