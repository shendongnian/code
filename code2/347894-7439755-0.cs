    object _resultLock;
    void Wait()
    {
      lock(_resultLock)
      {
         while (!_hasResult)
           Monitor.Wait(_resultLock);
      }
    }
    
    void Set(string results)
    {
      lock(_resultLock)
      {
         Results = results;
         _hasResult = true;
         Monitor.PulseAll(_resultLock);
      }
    }
