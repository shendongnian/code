    public string DatabaseFilter {
        get { return _databaseFilter; }
        set { 
            if(_databaseFilter != value) {
                _databaseFilter = value;
                FilterDatabases();
            }
        }
    }
