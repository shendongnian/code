    private void InitialiseDebugListener()
    {
        DebugListener dl = new DebugListener();
        dl.DebugMessage += new EventHandler<DebugArgs>(Console_OnDebugMessage);
        Debug.Listeners.Add(dl);
    }
    private void Console_OnDebugMessage(object sender, DebugMessageArgs e)
    {
        string debugMessage = e.Message;
     
        // Do what you want with debugMessage.
        // Be aware this may not come in on the application/form thread.
    }
