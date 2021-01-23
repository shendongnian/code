    HashSet<int> hs = new HashSet<int>(); // In common with all the threads
    int id = 1; // Your id
    // This will begin with short spins, every time trying to add the id to the hashset.
    // SpinUntil stops when the lambda function returns true.
    SpinWait.SpinUntil(() =>
    {
        lock (cd)
        {
            return hs.Add(id);
        }
    });
    // OR, if you know the operation is slow, or < .NET 4.0
    // This is clearer. The thread yields until it can add the id to the hashset.
    while (true)
    {
        lock (hs)
        {
            if (hs.Add(id))
            {
                break;
            }
        }
        Thread.Yield();
    }
    // End of the variant
    // Remember the try/finally! It's important in case of exceptions!!!
    try
    {
        // Put here your code
        // Put here your code
        // Put here your code
    }
    finally
    {
        lock (hs)
        {
            hs.Remove(id);
        }
    }
