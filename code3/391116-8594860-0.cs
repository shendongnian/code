    public void ExecuteWork(WaitCallback wcb, Object param)
    {
        Thread t = new Thread(
           o => 
           {
               wcb(o);
           });
        t.Start(param);
    }
    
