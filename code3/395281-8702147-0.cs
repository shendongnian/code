            Task<int> task1 = new Task<int>(() => { int sum = 0; return sum; });
            task1.Start();
            task1.Wait();
            Console.WriteLine("Result 1: {0}", task1.Result);
            Task<int> task2 = new Task<int>(() => { int sum = Enumerable.Range(1, 10).Sum(); return sum; });
            task2.Start();
            task1.Wait();
            Console.WriteLine("Result 2: {0}", task2.Result);
