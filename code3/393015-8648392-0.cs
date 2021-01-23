    public class MyContext : DbContext
    {
      public MyContext()
        : base(CreateConnection("Data Source=file.sdf", 
                                "System.Data.SqlServerCe.4.0"), true)
      { }
      public DbSet<Project> Projects { get; set; }
      public static bool TraceEnabled = true;
      private static DbConnection CreateConnection(string connectionString, 
                                                   string providerInvariantName)
      {
        DbConnection connection = null;
        if (TraceEnabled)
        {
          EFTracingProviderConfiguration.RegisterProvider();
          EFTracingProviderConfiguration.LogToConsole = true;
          string wrapperConnectionString = String.Format(@"wrappedProvider={0};{1}",
             providerInvariantName, connectionString);
          connection = new EFTracingConnection() 
          { 
            ConnectionString = wrapperConnectionString 
          };
        }
        else
        {
          DbProviderFactory factory = bProviderFactories.GetFactory(providerInvariantName);
          connection = factory.CreateConnection();
          connection.ConnectionString = connectionString;
        }
        return connection;
      }
    }
