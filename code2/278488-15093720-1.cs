    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    //dll Microsoft.SqlServer.Smo
    //dll Microsoft.SqlServer.Management.Sdk.Sfc
    //dll Microsoft.SqlServer.ConnectionInfo
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using Monitor.Common;
    
    namespace MonitorDB.DataLayer.Migrations
    {
      public class ExecuteSQLScripts :Monitor.Common.ExceptionHandling
      {
        public ExecuteSQLScripts()
        {
    }
    public bool ExecuteScriptsInDirectory(DBContext.SolArcMsgMonitorContext context, string scriptDirectory)
    {
      bool Result = false;
      try
      {
        SqlConnection connection = new SqlConnection(context.Database.Connection.ConnectionString);
        Server server = new Server(new ServerConnection(connection));
        DirectoryInfo di = new DirectoryInfo(scriptDirectory);
        FileInfo[] rgFiles = di.GetFiles("*.sql");
        foreach (FileInfo fi in rgFiles)
        {
          FileInfo fileInfo = new FileInfo(fi.FullName);
          string script = fileInfo.OpenText().ReadToEnd();
          server.ConnectionContext.ExecuteNonQuery(script);
        }
        Result = true;
      }
      catch (Exception ex)
      {
        CatchException("ExecuteScriptsInDirectory", ex);
      }
      return Result;
    }
