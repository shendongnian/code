    var columnOptions = new ColumnOptions
    {
        AdditionalDataColumns = new Collection<DataColumn>
        {
            new DataColumn {DataType = typeof (string), ColumnName = "User"},
            new DataColumn {DataType = typeof (string), ColumnName = "Other"},
        }
    };
    
    var log = new LoggerConfiguration()
        .WriteTo.MSSqlServer(@"Server=.\SQLEXPRESS;Database=LogEvents;Trusted_Connection=True;", "Logs", columnOptions: columnOptions)
        .CreateLogger();
