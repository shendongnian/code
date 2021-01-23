    static readonly object threadLock = new object();
    
    public void WriteToLog(string Msg)   
    {
        lock(threadLock)
        {   
            //Write to Log
        }
    }
