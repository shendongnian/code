    using System.Reflection;
    private void MonitorTasks(Delegate theDelegate, List<IAsyncResult> returnTags) 
    { 
        MethodInfo endInvoke = theDelegate.GetType().GetMethod("EndInvoke",
            new Type[] { typeof(IAsyncResult) });
        foreach (IAsyncResult returnTag in returnTags) {
            MessageType message = (MessageType) endInvoke.Invoke(theDelegate,
                new object[] { returnTag });
            messages.Add(message);
        } 
    }
