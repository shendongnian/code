    var connectionString = ConfigurationManager.ConnectionStrings["LogConnectionString"].ToString();
    var tableName = "Serilog_Logs";
    var customColumnOptions = new ColumnOptions();
    customColumnOptions.Store.Remove(StandardColumn.Properties); // Remove Column
    customColumnOptions.Store.Add(StandardColumn.LogEvent); // Add new column to default columns
    
    var logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .Enrich.WithProperty("TransactionId", transactionGuid)
        .WriteTo.MSSqlServer(connectionString: connectionString
            , tableName: tableName
            , schemaName: "LOG" // Schema should be create in database first
            , columnOptions: customColumnOptions
            , autoCreateSqlTable: true) // Will create the table if a table by that name doesn't exist
        .WriteTo.Console()
        .CreateLogger();
