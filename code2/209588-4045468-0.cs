    var dataBases = GetDatabaseList();
    private static IList<DataBase> GetDatabaseList() {
      var databases = new List<DataBase>();
      int numberOfDatabases = ConfigurationManager.AppSettings["NumberOfDatabases"].ToInt();
      for(int i = 1; i <= numberOfDatabases; i++)
        databases.Add(new DataBase
                        {
                          Identifier = ConfigurationManager.AppSettings["DatabaseName" + i],
                          ConnectionString = ConfigurationManager.AppSettings["ConnectionString" + i]
                        });
      return databases;
    }
  
