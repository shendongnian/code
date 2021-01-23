    // database abstraction
    interface IDatabase
    {
        void SaveSomeData(IData data);
    }
    
    // example of implementation
    class SQLDatabase : IDatabase
    {
        public SQLDatabase(string connection)
        {...}
    
        abstract void SaveSomeData(IData data)
        {
            // establish db connection using given connection and run sql queries against it.
        }
    }
    
    // proxy which can save data to several databases.
    class DatabaseSaver : IDataBase
    {
        private IDatabase[] _databases;
    
        public DatabaseSaver(IDatabase[] databases)
        {
            _databases = databases;
        }
    
        void SaveSomeData(IData data)
        {
            foreach(var db in _databases)
                db.SaveSomeData(data);
            // TODO: error handling situations are omitted.
        }
    }
