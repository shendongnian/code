     public static Database GetDataBaseInstance()
        {
            try
            {
                //Create an object of the Database class and get the database connection info
                Database db = DatabaseFactory.CreateDatabase(SqlConnectionString);
                return db;
            }
            catch
            {
                throw;
            }
        }  
