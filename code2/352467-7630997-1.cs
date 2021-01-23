    // Account table
    [Column(
        AutoSync = AutoSync.OnInsert,
        DbType = "Int NOT NULL IDENTITY",
        IsPrimaryKey = true,
        IsDbGenerated = true)]
    public int AccountID
    {
        get { return _AccountID; }
        set
        {
            if (_AccountID == value)
                return;
            NotifyPropertyChanging("AccountID");
            _AccountID = value;
            NotifyPropertyChanged("AccountID");
        }
    }
    // Transaction table
    [Column(
        AutoSync = AutoSync.OnInsert,
        DbType = "Int NOT NULL IDENTITY",
        IsPrimaryKey = true,
        IsDbGenerated = true)]
    public int TransactionID
    {
        get { return _TransactionID; }
        set
        {
            if (_TransactionID == value)
                return;
            NotifyPropertyChanging("TransactionID");
            _TransactionID = value;
            NotifyPropertyChanged("TransactionID");
        }
    }
