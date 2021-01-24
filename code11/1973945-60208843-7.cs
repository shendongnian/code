    var stopper = Stopwatch.StartNew();
    for (var i = ....)                                          //instead of foreach
    {
        if (i % 30 == 0)
        {
            if (stopper.ElapsedMilliseconds < 1000)
                Task.Delay(1000 - stopper.ElapsedMilliseconds); //note that this race condition should be avoided in your code
            stopper.Restart();
        }
        collection.Add(...);
    }
    collection.CompleteAdding();
