    public event EventHandler<MessageEventArgs> Done;
    protected virtual void OnDone(string message) {
        var handler = Done;
        if(handler != null) handler(this, new MessageEventArgs(message));
    }
