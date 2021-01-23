    public void DataTransfer(String sourceConnection, String destConnection, String pkgLocation)
    {     
        Package pkg;
        Application app;
        DTSExecResult pkgResults;
        try
        {
            app = new Application();
            pkg = app.LoadPackage(pkgLocation, null);
            foreach (ConnectionManager connectionManager in pkg.Connections)
            {
                SqlConnectionStringBuilder builder;
                switch (connectionManager.Name)
                {
                    case "SourceConnection":
                        builder = new SqlConnectionStringBuilder(sourceConnection) { PersistSecurityInfo = true };
                        builder.Remove("Initial Catalog");
                        builder.Add("Initial Catalog", "StagingArea");
                        var sourceCon = builder.ConnectionString + ";Provider=SQLNCLI;Auto Translate=false;";
                        //Added spaces to retain password!!!
                        sourceCon = sourceCon.Replace(";", "; ");
                        connectionManager.ConnectionString = sourceCon;
                        Debug.WriteLine(connectionManager.ConnectionString.ToString());
                        break;
                    case "DestinationConnection":
                        builder = new SqlConnectionStringBuilder(sourceConnection) { PersistSecurityInfo = true };
                        builder.Remove("Initial Catalog");
                        builder.Add("Initial Catalog", "StagingArea");
                        var destCon = builder.ConnectionString + ";Provider=SQLNCLI;Auto Translate=false;";
                        //Added spaces to retain password!!!
                        destCon = destCon.Replace(";", "; ");
                        connectionManager.ConnectionString = destCon;
                        Debug.WriteLine(connectionManager.ConnectionString.ToString());
                        break;
                }
            }
            pkgResults = pkg.Execute();
        }
        catch (Exception e)
        {
            throw;
        }
        Console.WriteLine(pkgResults.ToString());
    }
