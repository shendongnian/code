    object ICollection.SyncRoot
    {
        get
        {
            if (this._syncRoot == null)
            {
                Interlocked.CompareExchange(ref this._syncRoot, new object(), null);
            }
            return this._syncRoot;
        }
    }
