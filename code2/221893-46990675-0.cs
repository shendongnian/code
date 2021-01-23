        database = new SQLiteConnection(databasePath);
        
        public int GetLastInsertId()
        {
            return (int)SQLite3.LastInsertRowid(database.Handle);
        }
