    System.Threading.ThreadPool.QueueUserWorkItem( o =>
    {
       try
       {
          svc.SomeMethodAsync();
       }
       catch (err)
       {
           // do something sensible with err
       }
    });
