    public void Synchronize()
    {
        if (this.IsDisposed || this.Disposing) return; // or return a 'remove me' flag
        ... 
        // sync
    }
