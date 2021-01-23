    internal void Execute()
    {
        for (int i = 7; i < 10000; i++)
        {
            // trimmed for brevity: create a copy of i
            int copy = i;
            new Thread(new ThreadStart(delegate
            {
                _lock.EnterWriteLock();
                try
                {
                    _dict.Add(copy, copy); // Exception after random number of loops
                    Console.WriteLine(copy.ToString() + " added");
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            })).Start();
        }
