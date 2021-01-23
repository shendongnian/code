    SynchronizationContext syncContext = null;
    ...
    // "object state" is required to be a callback for Post
    public void HiThar(object state) { 
      if (syncContext == null) {
        syncContext = SynchronizationContext.Current;
      } else {
        syncContext.Post(HiThar, state);
      }
    }
