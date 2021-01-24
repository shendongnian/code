    Task thatTask;
    CancellationTokenSource cts;
    public void StartTheJob()
    {
        cts=new CancellationTokenSource();
        thatTask=Task.Run(()=>progr(cts.Token));
    }
