    private bool _askedToCancel;
    public void lonRunThread()
    {
        if (!_askedToCancel)
        {
            Operation1();
            Invoke(new UpdateDelegate(updateState));
        }
            
        if (!_askedToCancel)
        {    
            Operation2();
            Invoke(new UpdateDelegate(updateState));
        }
    }
