    void IncrementCount()
    {
       mre.Wait();
       // lets not cause a race, lock until OverwriteCount is finished
       lock (_sync)
       {
          _myCount++;
       }
    }
    
    void OverwriteCount(int newValue)
    {
       // lock this so we can assure the count is updated
       lock (_sync)
       {
          mre.Reset(); // unsignal the event, blocking threads
          _myCount = newValue;
       }
    }
    
    void OnTimer()
    {
       Console.WriteLine(_myCount);
       mre.Set(); // signal the event
    }
