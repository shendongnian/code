    protected void CheckReentrancy()
    {
        if ((this._monitor.Busy && (this.CollectionChanged != null)) && (this.CollectionChanged.GetInvocationList().Length > 1))
        {
            throw new InvalidOperationException(SR.GetString("ObservableCollectionReentrancyNotAllowed"));
        }
    }
