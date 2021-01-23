    protected EventHandler GlobalMessageEvent = new EventHandler<MyEventArgs>(Global_Message);
    protected virtual void OnSubscribeToMessageEvent() 
    {
        // this could be done in the Form_Load() or constructor instead.
        Global.Message += GlobalMessageEvent;
    }
