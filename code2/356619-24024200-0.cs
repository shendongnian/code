    var threadDbConn = new ThreadLocal<MyDbConnection>(() => MyDbConnection.Open(), true);
    try
    {
        Parallel.For(0, 10000, i =>
        {
            var inputData = threadDbConn.Value.GetData(i);
            ...
        });
    }
    finally
    {
        foreach(var dbConn in threadDbConn.Values)
        {
            dbConn.Close();
        }
    }
