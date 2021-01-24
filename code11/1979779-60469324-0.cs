    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
----------
    var script = new StringBuilder();
    
    Server server = new Server(new ServerConnection(new SqlConnection(connectionString)));
    Database database = server.Databases[databaseName];
    ScriptingOptions options = new ScriptingOptions
    {
    	ScriptData = true,
    	ScriptSchema = true,
    	ScriptDrops = false,
    	Indexes = true,
    	IncludeHeaders = true
    };
    
    foreach (Table table in database.Tables)
    {
    	foreach (var statement in database.Tables[table.Name].EnumScript(options))
    	{
    		script.Append(statement);
    		script.Append(Environment.NewLine);
    	}
    }
    
    File.WriteAllText(backupPath + databaseName + ".sql", script.ToString());
