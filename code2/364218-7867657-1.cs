    public int NextId()
    {
        return Interlocked.Increment(ref _transactionId);
    }
    public void Set(int value)
    {
        Interlocked.Exchange(ref _transactionId, value);
    }
