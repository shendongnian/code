    public class Factory
    {
        private static readonly string dbType = ConfigurationSettings.Appsettings["SqlServer"];
        public static IDataAccess GetInstance()
        { 
            switch(dbType)
            {
                 case "SqlServer":
                    return new SqlServerDataAccess(); //SqlServerDataAccess should implement IDataAccess
                 break;
                 case: "MySql":
                    return new MySqlDataAccess(); //MySqlDataAccess should implement IDataAccess
                 break;
                 default: "No datasource";
            }
        }
    }
