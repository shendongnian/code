    public event EventHandler<MsgEventArgs> MsgReceived
    {
        add
        {
            foreach (MsgObject mo in msgs)
                value(this, new MsgEventArgs() { Message = mo });
            
            ...
        }
        remove
        {
            ...
        }
    }
