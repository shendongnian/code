    static class StatusManager
    {
        delegate onMessageReceivedEvent(string message);
        static event onMessageReceivedEvent OnMessageReceived;
    
        static void PostMessage(string message)
        {
            if(OnMessageReceived != null)
                 OnMessageReceived.Invoke();
        }
    }
