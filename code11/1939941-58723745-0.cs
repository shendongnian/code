    public async static void InitializeDatabase()
    { 
         await ApplicationData.Current.LocalFolder.CreateFileAsync("sqliteSPSystem.db", CreationCollisionOption.OpenIfExists);
         string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "sqliteSPSystem.db");
         using (SqliteConnection db =
            new SqliteConnection($"Filename={dbpath}"))
        {
            db.Open();
    
            String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS ParkingData (Primary_Key INTEGER PRIMARY KEY, " +
                    "TimeIN NVARCHAR(2048) NULL,TimeOUT NVARCHAR(2048) NULL)";
            SqliteCommand createTable = new SqliteCommand(tableCommand, db);
    
            createTable.ExecuteReader();
        }
    }
