    private bool notifMatchStarted;
    public UnityEvent MatchStarted;
    void Update()
    {
        //Invoke events here to guarantee they are called from the main thread.
        if(notifMatchStarted)
        {
            MatchStarted.Invoke();
            notifMatchStarted = false;
        }
    }
    public void MatchReady()
    {
        //Handle notifications from the server
        _client.Socket.OnNotification += (_, notification) =>
        {
            switch (notification.Code)
            {
                case 1:
                    notifMatchStarted = true;
                    break;
            }
        };
    }
 
