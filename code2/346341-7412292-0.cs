    public class DatabaseBackup
    {
        private ServerConnection Connection;
        private Server Server;
        private Database Database;
        private ScriptingOptions Options;
        private string FileName;
        private const string NoDataScript = "Cars";
    
        public DatabaseBackup(string server, string login, string password, string database)
        {
            Connection = new ServerConnection(server, login, password);
            Server = new Server(Connection);
            Database = Server.Databases[database];
        }
    
        public void Backup(string fileName)
        {
            FileName = fileName;
            SetupOptions();
    
            foreach (Table table in Database.Tables)
            {
                 if (!table.IsSystemObject)
                 {
                      if (NoDataScript.Contains(table.Name))
                      {
                           Options.ScriptData = false;
                           table.EnumScript(Options);
                           Options.ScriptData = true;
                      }
                      else
                           table.EnumScript(Options);
                  }
             }
        }
    
        private void SetupOptions()
        {
             Options = new ScriptingOptions();
             Options.ScriptSchema = true;
             Options.ScriptData = true;
             Options.ScriptDrops = false;
             Options.WithDependencies = true;
             Options.Indexes = true;
             Options.FileName = FileName;
             Options.EnforceScriptingOptions = true;
             Options.IncludeHeaders = true;
             Options.AppendToFile = true;
        }
    }
