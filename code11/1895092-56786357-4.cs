    // for sending back responses to the main thread
    private ConcurrentQueue<Action> callbacks = new ConcurrentQueue<Action>;
 
    // work the callbacks in the main thread
    private void Update()
    {
        while(callbacks.Count > 0)
        {
            Action callback;
            if(callbacks.TryDequeue(out callback)) callback?.Invoke();
        }
    }
    // optional callback on success
    public void StartBackgroundTask(Action onSuccess = null)
    {
        var thread = new Thread(new ParameterizedThreadStart(TheTaskThatTakesAWhile);
        // pass in parameters here
        thread.Start(onSuccess);
    }
    // Will be running in a background thread
    private void TheTaskThatTakesAWhile(Action onSuccess)
    {
        // hand this back to the main thread
        callbacks.Enqueue(() => Debug.Log("Long task started ..."));
        // TODO whatever takes so long
        // Note btw that sleep is in milliseconds!
        Thread.Sleep(1000);
        hand this back to the mainthread
        callbacks.Enqueue(() => 
        {
            Debug.Log("Long task started ..."));
 
            onSuccess?.Invoke();
        }
    }
