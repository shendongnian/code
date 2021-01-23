    using System.Configuration;
    using System.Data.SqlClient;
    using Microsoft.SqlServer.Management.Common;
    public class Foo
    {
        public static void DropDatabase(string connectionName)
        {
            using (
                var sqlConnection =
                    new SqlConnection(
                        ConfigurationManager.ConnectionStrings[connectionName]
                        .ConnectionString))
            {
                var serverConnection = new ServerConnection(sqlConnection);
                var server = new Microsoft.SqlServer.Management.Smo.Server(
                                 serverConnection);
                server.KillDatabase(sqlConnection.Database);
            }
        }
    }
