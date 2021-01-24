    var parent = Task.Run(() =>
    {
        int[] tab = new int[3];
    
        var child1 = Task.Run(() =>
        {
            tab[0] = 9;
            Thread.Sleep(4000);
            Console.WriteLine("Child1");
        });
        var child2 = Task.Run(() =>
        {
            tab[1] = 2;
            Thread.Sleep(2000);
            Console.WriteLine("Child2");
        });
    
        var child3 = Task.Run(() =>
        {
            tab[2] = 3;
            Thread.Sleep(1000);
            Console.WriteLine("Child3");
        });
    
        Task.WaitAll(child1, child2, child3);  //Wait for all 3 threads to complete. 
    
        Console.WriteLine("I am here");
        return tab;
    });
    
    var finalTask = parent.ContinueWith((a) =>
    {
        a.Result.ToList().ForEach(Console.WriteLine);
    });
    
    finalTask.Wait();
    Console.WriteLine("Out of threads");
    Console.ReadLine();
