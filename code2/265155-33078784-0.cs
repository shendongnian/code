      `  public void CreateScriptTable() 
        {
            ServerConnection serverConnection = new ServerConnection(".");
            Server server = new Server(serverConnection);
            Database database = server.Databases["ff"];
            Table tb = database.Tables["t"];
            Scripter scripter = new Scripter(server);
            scripter.Options.ScriptData = true;
            var sb = new StringBuilder();
            foreach (string s in scripter.EnumScript(new Urn[] { tb.Urn }))
                sb.Append(s);
            System.IO.StreamWriter fs = System.IO.File.CreateText(@"ScriptTable");
            fs.Write(sb);
            fs.Close();
        } ` 
