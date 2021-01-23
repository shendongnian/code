    bool IsUpdateLastTime
    {
     get
     {
        // logic here even can be fully or partially injected 
        // as Func<bool>
        return this.IsSyncA || this.IsSyncB;
     }
    }
    
    bool IsSyncA { get { return synchA.Checked; } }
    bool IsSyncB { get { return synchB.Checked; } }
