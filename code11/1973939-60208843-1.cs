    var stopper = Stopwatch.StartNew();
    while(!collection.IsComplete)
    {
        for (var i = 0; i < 30; i++)
        {
            if (collection.IsComplete)
                break;
            await collection.Take();
        }
        if (stopper.ElapsedMilliseconds < 1000)
            Task.Delay(1000 - stopper.ElapsedMilliseconds);   //note that this race condition should be avoided in your code
    }
