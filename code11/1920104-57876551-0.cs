    _database = new SQLiteAsyncConnection(
         "myDbSQLite.db3", 
         SQLiteOpenFlags.Create | 
         SQLiteOpenFlags.FullMutex | 
         SQLiteOpenFlags.ReadWrite );
