    class RulyCanceler
    {
      object _cancelLocker = new object();
      bool _cancelRequest;
      public bool IsCancellationRequested
      {
        get { lock (_cancelLocker) return _cancelRequest; }
      }
     
      public void Cancel() { lock (_cancelLocker) _cancelRequest = true; } 
     
      public void ThrowIfCancellationRequested()
      {
        if (IsCancellationRequested) throw new OperationCanceledException();
      }
    }
