    int totalRecords = MyList.Count();
    int batchSize = 250;
            
    Parallel.ForEach(Partitioner.Create(0, totalRecords, batchSize), range =>
    {
        foreach (var thing in MyList.Skip(range.Item1).Take(batchSize))
        {
            DoStuff(thing);
            //logging and stuff...           
        }
    });
