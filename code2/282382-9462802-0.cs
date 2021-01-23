     SQLiteConnectionStringBuilder connBuilder = new SQLiteConnectionStringBuilder();
            connBuilder.DataSource = filePath;
            connBuilder.Version = 3;
            connBuilder.CacheSize = 4000;            
            connBuilder.DefaultTimeout = 100;
            connBuilder.Password = "mypass";
            
            using(SQLiteConnection conn = new SQLiteConnection(connBuilder.ToString()))
            {
                //...
            }
