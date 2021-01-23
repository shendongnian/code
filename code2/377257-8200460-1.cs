    private DateTime called;
    
    public TranlationStatus()
    {
        this.called = DateTime.Now; 
    }
    
    public ToString()
    {
        if (this.called - DateTime.Now < new TimeSpan(0,0,20))
        {
            return TransationStatus.Pending.ToString();
        }
        else
        {
            return TransactionStatus.Complete.ToString();
        }
    }
