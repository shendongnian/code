    public void DoLenghtyWork()
    {
        if(!bgWorker.CancellationPending)
        {              
            OtherStuff();
            for(int i=0 ; i<10000000; i++) 
            {  
                 int j = i/3; 
            }
        }
    }
    public void OtherStuff()
    {
        if(!bgWorker.CancellationPending)
        {  
            for(int i=0 ; i<10000000; i++) 
            {  
                int j = i/3; 
            }
        }
    }
