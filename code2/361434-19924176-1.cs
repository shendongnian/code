    public void DoIt(IToBeDone doit)
    {
        // this will cause that IToBeDone won't be used for type resolution but the real
        // type instead (in my case MyDoIt)
        dynamic dynDoit = doit;
        _doItInstance.DoIt(dynDoit);
    }
    
