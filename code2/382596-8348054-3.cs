    if (Log.IsDebugEnabled)
    {
        StackFrame f = new StackFrame(2);
        Log.Debug("Very expensive message to put together and stuff." + f.GetMethod().Name);
    }
	if (Log.IsInfoEnabled)
    {
        StackFrame f = new StackFrame(2);
        Log.Debug("Very expensive message to put together and stuff." + f.GetMethod().Name);
    }
	if (Log.IsErrorEnabled)
    {
        StackFrame f = new StackFrame(2);
        Log.Debug("Very expensive message to put together and stuff." + f.GetMethod().Name);
    }
