     TaskFactory myFactory = new TaskFactory();
     myFactory.StartNew(method).ContinueWith(delegate
     {
        Task t1 = myFactory.StartNew(method2);
        Task t2 = myFactory.StartNew(method3);
        myFactory.ContinueWhenAll(new [] {t1, t2}, method4);
     });
