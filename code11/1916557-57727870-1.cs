    /// <summary>
    /// Copy database to new database on same server
    /// </summary>
    /// <param name="pOriginalDatabase">Database to copy</param>
    /// <param name="pNewDatabase">Copy to database with unique database name</param>
    /// <returns></returns>
    public bool CopyDatabase(string pOriginalDatabase, string pNewDatabase)
    {
    
        var srv = new Server();
        Database db = null;
    
        db = srv.Databases[pOriginalDatabase];
        Database dbCopy = null;
        dbCopy = new Database(srv, pNewDatabase);
        dbCopy.Create();
    
        Transfer trans = null;
        trans = new Transfer(db)
        {
            CopyAllTables = false,
            Options =
                {
                    WithDependencies = true,
                    ContinueScriptingOnError = true
                },
            DestinationDatabase = pNewDatabase,
            DestinationServer = srv.Name,
            DestinationLoginSecure = true
        };
        trans.Options.DriAllKeys = true;
        trans.CopySchema = true;
    
        trans.TransferData();
    
        return true;
    
    }
