    for (int i = 7; i < 10000; i++)
    {
        // Other stuff...
        copyOfI = i;
        new Thread(new ThreadStart(delegate
        {
            _lock.EnterWriteLock();
            try
            {
                _dict.Add(copyOfI, copyOfI);
                Console.WriteLine(copyOfI.ToString() + " added");
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        })).Start();
    }
