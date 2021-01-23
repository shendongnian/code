    foreach(var process in _myProcesses)
    {
        waitHandles.Add(OpenExistingOrCreateEventWaitHandle(process.SharedWaitHandleName);
    }
    
    ...
    internal static EventWaitHandle OpenExistingOrCreateEventWaitHandle(string name)
    {
        try
        {
            return EventWaitHandle.OpenExisting(name);
        }
        catch (WaitHandleCannotBeOpenedException)
        {
            return new EventWaitHandle(false, EventResetMode.AutoReset, name);
        }
    }
    
    ...
    foreach(var waitHandle in waitHandles)
    {
        waitHandle.Set();
    }
