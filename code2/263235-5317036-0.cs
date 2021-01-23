     public static string GetConnectionString()
        {
            Database YourData = DatabaseFactory.CreateDatabase("someconnectionname");
            return YourData .ConnectionString;
        }
