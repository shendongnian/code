    const int BatchSize = 250;
            
    int totalRecords = MyList.Count();
    var partitioner = Partitioner.Create(0, totalRecords, BatchSize);
    var options = new ParallelOptions { MaxDegreeOfParallelism = 2 };
    Parallel.ForEach(partitioner, options, range =>
    {
        foreach (int thing in MyList.Skip(range.Item1).Take(BatchSize))
        {
            DoStuff(thing);
            //logging and stuff...           
        }
    });
