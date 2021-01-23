    static void Main(string[] args)
    {
       // grab that from a config file in your real app!
       string connectionString = "server=(local);database=YourDB;Integrated Security=SSPI;";
       GetDefaultColumnValues getter = new GetDefaultColumnValues();
       List<ColumnAndDefault> columnDefaults = 
          getter.GetDefaultsForTable("YourTableNameHere", connectionString);
    }
