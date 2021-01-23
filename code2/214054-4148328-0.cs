        try
        {
           string connectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", _databaseFileName, _password);
           using (SqlCeEngine engine = new SqlCeEngine(connectionString))
           {
              engine.CreateDatabase();
           }
        }
        catch (SqlCeException)
        {
        }
