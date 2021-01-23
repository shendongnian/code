    public string DequeueOrNull()
    {
      lock (_lockObject)
      {
        if (IsEmpty())
          return null;
        return Dequeue();
      }
    }
