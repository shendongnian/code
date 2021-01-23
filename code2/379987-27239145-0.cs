    var dialect = sess.GetSessionImplementation().Factory.Dialect;                               
    var dbSchema = dialect.GetDataBaseSchema(sess.Connection as DbConnection);               
                
    foreach (DataRow row in (sess.Connection as DbConnection).GetSchema("Tables").Rows)
    {
        ITableMetadata md =  dbSchema.GetTableMetadata(row, false);
        var hiddenColumnsProperty = typeof(AbstractTableMetadata).GetField("columns", BindingFlags.NonPublic | BindingFlags.Instance);
        var columns = hiddenColumnsProperty.GetValue(md) as Dictionary<string, IColumnMetadata>;                  
        foreach (var colName in columns.Keys)
        {
            Console.WriteLine(md.Name+"."+colName);
        }
    }
