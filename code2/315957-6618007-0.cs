    public string DequeueOrNull()
    {
        if (IsEmpty())
            return null;
    ///  << it is possible that the Dequeue is called from another thread here.
        return Dequeue();
    }
