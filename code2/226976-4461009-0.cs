    public Svc()
    {
        this.CallbackChannel = OperationContext.Current.GetCallbackChannel<ICallback>();
        
        // The static 'Instance' property returns the singleton
        SvcActiveInstanceContainer.Instance.Add(this);
    }
