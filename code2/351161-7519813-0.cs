        Task t1 = Task.Factory.StartNew(() => { Save<Foo>(ConcurrentCollectionStorage.Bus1); });
        Task t2 = Task.Factory.StartNew(() => { Save<Bar>(ConcurrentCollectionStorage.Bus2); });
        Task t3 = Task.Factory.StartNew(() => { Save<Car>(ConcurrentCollectionStorage.Bus3); });
       
        Task.WaitAll(t1,t2,t3);
