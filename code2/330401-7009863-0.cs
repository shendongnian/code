    using System.Threading;
    protected override void OnStart(string[] args)
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback((_) =>
        {
            Thread.Sleep(5 * 1000 * 60);//simulate 5 minutes work
          
           // do something
        }));
    }
