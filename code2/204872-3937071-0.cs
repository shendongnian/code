    Thread t1=new Thread( delegate() { wsResult = CallWebService(); } );
    Thread t2=new Thread( delegate() { dbResult = QueryDb(); } );
    Thread t3=new Thread( delegate() { cacheResult = QueryLocalCache(); } );
    t1.Start(); t2.Start(); t2.Start();
    t1.Join(); t2.Join(); t3.Join();
