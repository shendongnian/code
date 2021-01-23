    StringBuilder sb = new StringBuilder();
    using (SqlConnection connection = new SqlConnection("connectionString")) {
        ServerConnection serverConnection = new ServerConnection(connection);
        Server server = new Server(serverConnection);
        Database database = server.Databases["databaseName"];
        Scripter scripter = new Scripter(server);
        scripter.Options.ScriptDrops = false;
        scripter.Options.WithDependencies = true;
        scripter.Options.ScriptData = true;
        Urn[] smoObjects = new Urn[1];
        foreach (Table table in database.Tables) {
            smoObjects[0] = table.Urn;
            if (!table.IsSystemObject) {
                foreach (string s in scripter.EnumScript(smoObjects)) {
                    System.Diagnostics.Debug.WriteLine(s);
                    sb.AppendLine(s);
                }
            }
        }
    }
    // Write to *.sql file on disk
    File.WriteAllText(@".\backup.sql");
