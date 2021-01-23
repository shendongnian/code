    var o = Observable.Start
    (
        () => 
        { 
            Console.WriteLine("Calculating..."); 
            Thread.Sleep(3000); 
            Console.WriteLine("Done."); 
        }
    );
    o.First();   // subscribe and wait for completion of background operation
