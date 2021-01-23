    // written from the head
    ...
    using System.Data.SqlClient;
    using Smo = Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    
    string strConnectionString = ".......";
    string strAlterProcCommandText = "ALTER PROC dbo.blablabla (..) AS .......\r\nGO";
    
    using (var conn = new SqlConnection(strConnectionString))
    {
      conn.Open();
      var server = new Smo.Server(new ServerConnection(conn));
      var result = server.ConnectionContext.ExecuteNonQuery(strAlterProcCommandText);
      Console.WriteLine("Result: " + result);
    }
