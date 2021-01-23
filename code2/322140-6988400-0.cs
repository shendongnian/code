    public static void ExecuteWait(Action action)
    {
       var waitFrame = new DispatcherFrame();
        
       // Use callback to "pop" dispatcher frame
       action.BeginInvoke(dummy => waitFrame.Continue = false, null);
        
       // this method will wait here without blocking the UI thread
       Dispatcher.PushFrame(waitFrame);
    }
