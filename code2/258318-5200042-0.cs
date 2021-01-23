    using Microsoft.SqlServer.Management.Smo;
        using Microsoft.SqlServer.Server;
        using Microsoft.SqlServer.Management.Common;
        using Microsoft.SqlServer;
    
        string srcDB = "foo";
        string destDB = "bar";
        string proc = "aStoredProc";
    
    
    __DevSqlConnection = new SqlConnection(__DevSqlConnectionString);
                    __DevSqlConnection.Open();
    
                    __TestingSqlConnection = new SqlConnection(__TestingSqlConnectionString);
                    __TestingSqlConnection.Open();
    
                    //SMO Server object setup with SQLConnection.
                    Server devServer = new Server(new ServerConnection(__DevSqlConnection));
                    //Set Database 
                    Database db = devServer.Databases[srcDB];
    
                    //SMO For the Receiving Server
                    Server testServer = new Server(new ServerConnection(__TestingSqlConnection));
                    //Set Database
                    Database tdb = testServer.Databases[destDB];
    
                    //Set the proc we wish to Script
                    StoredProcedure transferProc = db.StoredProcedures[proc];
                    transferProc.TextMode = false;
                    transferProc.AnsiNullsStatus = false;
                    transferProc.QuotedIdentifierStatus = false;
    
                    //Create an SPObj for the new server.
                    StoredProcedure tProc = new StoredProcedure(tdb, proc);
    
    
                    //Create the Creation Script.
                    ScriptingOptions so = new ScriptingOptions();
                    StringCollection script = transferProc.Script(so);
                    string[] scriptArray = new string[script.Count];
                    script.CopyTo(scriptArray, 0);
                    foreach (string line in scriptArray)
                    {
                        if (line.IndexOf("CREATE", StringComparison.CurrentCulture) >= 0)
                            __SchemaScript += line + Environment.NewLine;
                    }
    
    
                    //Run the script against the target testing DB.
                    SqlCommand cmdCreate = new SqlCommand(__SchemaScript, __TestingSqlConnection);
                    cmdCreate.CommandType = CommandType.Text;
                    cmdCreate.CommandTimeout = 7200;
                    cmdCreate.ExecuteNonQuery();
