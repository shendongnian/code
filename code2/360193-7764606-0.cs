    void Init()
    {
        SystemEvents.SessionEnding += 
            new SessionEndingEventHandler(SystemEvents_SessionEnding);
    }
    
    void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
    {
        // Do what you need
    }
