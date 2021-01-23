    public abstract class MyDbContext : DbContext
    {
        protected MyDbContext(string nameOrConnectionString)
            : base(CreateTracingConnection(nameOrConnectionString), true)
        {
            // enable sql tracing
            ((IObjectContextAdapter) this).ObjectContext.EnableTracing();
        }
    
        private static DbConnection CreateTracingConnection(string nameOrConnectionString)
        {
            try
            {
                // this only supports entity connection strings http://msdn.microsoft.com/en-us/library/cc716756.aspx
                return EFTracingProviderUtils.CreateTracedEntityConnection(nameOrConnectionString);
            }
            catch (ArgumentException)
            {
                // an invalid entity connection string is assumed to be a normal connection string name or connection string (Code First)
    
                ConnectionStringSettings connectionStringSetting =
                    ConfigurationManager.ConnectionStrings[nameOrConnectionString];
                string connectionString;
                string providerName;
    
                if (connectionStringSetting != null)
                {
                    connectionString = connectionStringSetting.ConnectionString;
                    providerName = connectionStringSetting.ProviderName;
                }
                else
                {
                    providerName = "System.Data.SqlClient";
                    connectionString = nameOrConnectionString;
                }
    
                return CreateTracingConnection(connectionString, providerName);
            }
        }
    
        private static EFTracingConnection CreateTracingConnection(string connectionString, string providerInvariantName)
        {
            // based on the example at http://jkowalski.com/2010/04/23/logging-sql-statements-in-entity-frameworkcode-first/
            string wrapperConnectionString =
                String.Format(@"wrappedProvider={0};{1}", providerInvariantName, connectionString);
    
            EFTracingConnection connection =
                new EFTracingConnection
                    {
                        ConnectionString = wrapperConnectionString
                    };
    
            return connection;
        }
    }
