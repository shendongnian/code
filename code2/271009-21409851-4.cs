    List<int> iList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
    System.Threading.Tasks.ParallelOptions opt = new System.Threading.Tasks.ParallelOptions();
    opt.MaxDegreeOfParallelism = 4; // << here the maximum of 4 cores
    System.Threading.Tasks.Parallel.ForEach<int>(iList, opt, i =>
    {
        // do someting with parallelism 4
        Console.WriteLine(i);
    });
