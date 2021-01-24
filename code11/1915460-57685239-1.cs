    private MainThreadDispatcher mainThreadDispatcher;
    void OnEnable()
    {
        // before dispatching stuff make sure an instance reference is optained
        // or is created in the main thread
        mainThreadDispatcher = MainThreadDispatcher.Instance;
        EventSystemManager.StartListening("printMessage", AddMessage);   
    }
    // might be executed in a thread
    public void AddMessage(string message ) 
    {
        // instead of directly executing the code wait for the main thread
        // either using a lambda expression
        mainThreadDispatcher.Dispatch(() =>
            {
                GameObject remoteMessage = Instantiate(localMessagePrefab, 
                chatTransform);
                remoteMessage.transform.GetChild(0).GetComponentInChildren<Text> 
                ().text = message;
            });
        // or if you prefer a method
        //mainThreadDispatcher.Dispatch(HandleAddMessage);
    }
    
    // should be only executed in the main thread
    private void HandleAddMessage()
    {
        GameObject remoteMessage = Instantiate(localMessagePrefab, 
        chatTransform);
        remoteMessage.transform.GetChild(0).GetComponentInChildren<Text> 
        ().text = message;
    }
