    Thing thing = createThing(1);
    DateTime startTime = DateTime.Now;
    thing.ComputationallyExpensiveOp();
    TimeSpan elapsed = DateTime.Now - startTime;
    Console.WriteLine(String.Format("i = " + 1 + "\ttime = " + elapsed.TotalMilliseconds);
    for (int i = 1; i <= 1000; i++)
    {
        thing = createThing(i);
    
        startTime = DateTime.Now;
        thing.ComputationallyExpensiveOp();
        elapsed = DateTime.Now - startTime;
    
        Console.WriteLine(String.Format("i = " + i + "\ttime = " + elapsed.TotalMilliseconds);
    }
