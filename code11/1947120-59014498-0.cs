        Stopwatch s = new Stopwatch();
        s.Start();
        {
                Task T1 = Task.Run(() =>
                {
                    for (int i = 0; i <= 5000; i++)
                        Console.WriteLine("Test1:" + i);
                });
                Task T2 = Task.Run(() =>
                {
                    for (int i = 0; i <= 5000; i++)
                        Console.WriteLine("Test2:" + i);
                });
                Task T3 = Task.Run(() =>
                {
                    for (int i = 0; i <= 5000; i++)
                        Console.WriteLine("Test3:" + i);
                });
        
        		Task.WaitAll(T1,T2,T3); // Change here
       }
       s.Stop();
       Console.WriteLine("Press any key to quit");
       Console.WriteLine("Total Task Ellapsed time -> {0}", s.ElapsedMilliseconds);
