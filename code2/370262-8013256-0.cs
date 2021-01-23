    ExecuteSqlScriptResource("MyDb", "MyAssemblyName.Scripts.aspnet_regsql_add.sql");
    // ...
    static void ExecuteSqlScriptResource(string connectionName, string resourcePath)
    {
        using (Stream scriptStream = Assembly.GetExecutingAssembly()
            .GetManifestResourceStream(resourcePath)
            )
        {
            if (scriptStream == null)
            {
                WriteLine(string.Format("Failed to open resource {0}", resourcePath));
                return;
            }
            using (
                var sqlConnection = new SqlConnection(
                    ConfigurationManager
                        .ConnectionStrings[connectionName].ConnectionString
                    )
                )
            {
                using (var streamReader = new StreamReader(scriptStream))
                {
                    var svrConnection = new ServerConnection(sqlConnection);
                    var server = new Server(svrConnection);
                    server.ConnectionContext.ExecuteNonQuery(streamReader.ReadToEnd());
                }
            }
        }
    }
