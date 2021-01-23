    public static void ThreadSafe(Action action)
    {
        Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Normal, 
            new MethodInvoker(action));
    }
