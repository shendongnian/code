    public SqlConnection() {
      this.ObjectID = Interlocked.Increment(ref SqlConnection._objectTypeCount);
      base();
      GC.SuppressFinalize(this);
      this._innerConnection = DbConnectionClosedNeverOpened.SingletonInstance;
    }
