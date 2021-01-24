    public static class ConnectionString
        {
            public static string DataSource { get; set; }
            public static string InitialCatalog { get; set; }
            public static Boolean IntegratedSecurity { get; set; }
            public static string ApplicationName { get; set; }
            public static int ConnectTimeout { get; set; }
    
    
            static ConnectionString()
            {
                DataSource = Settings.Default.DataSource ?? @"(local)";
                InitialCatalog = Settings.Default.InitialCatalog ?? @"ApartmentManagementSystem";
                IntegratedSecurity = Settings.Default.IntegratedSecurity;
                ApplicationName = Settings.Default.ApplicationName ?? System.IO.Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);
                ConnectTimeout = Settings.Default.ConnectTimeout;
            }
            /// <summary>
            /// fetch default sql connection from settings
            /// </summary>
            /// <returns>Connection String</returns>
            public static string GetConnectionString()
            {
                var _connection = new SqlConnectionStringBuilder()
                {
                    DataSource = ConnectionString.DataSource,
                    InitialCatalog = ConnectionString.InitialCatalog,
                    IntegratedSecurity = ConnectionString.IntegratedSecurity,
                    ApplicationName = ConnectionString.ApplicationName,
                    ConnectTimeout = ConnectionString.ConnectTimeout
                };
                return _connection.ConnectionString;
            }
        }
