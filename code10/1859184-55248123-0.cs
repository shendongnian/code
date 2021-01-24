    var connectionString = @"Data Source=.\SQLEXPRESS;Integrated Security=SSPI;Database=Serilog_DB;";
    var tableName = "Serilog_Logs";
    var customColumnOptions = new ColumnOptions();
    customColumnOptions.Store.Remove(StandardColumn.Properties); // Remove Column
    customColumnOptions.Store.Add(StandardColumn.LogEvent); // Add new column to default coulmes 
    
    var logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .Enrich.WithProperty("TransactionId", transactionGuid)
        .WriteTo.MSSqlServer(connectionString: connectionString
            , tableName: tableName
            , schemaName: "LOG" // Schema should be create in database first
            , columnOptions: customColumnOptions
            , autoCreateSqlTable: true)
        .WriteTo.Console()
        .CreateLogger();
