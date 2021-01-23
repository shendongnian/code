    public void OnMessageRecieved(Object sender, Events e) //Not the real signature
    {
        MessageMonitor.Created -= OnMessageReceived();
        //Do Your things
        OtherMessageMonitor.Created += OnMessageReceived();
    }
