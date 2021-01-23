    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.SqlClient;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Smo.Agent;
    
    
    // Add references: (in c:\Program Files\Microsoft SQL Server\90\SDK\Assemblies\)
    // Microsoft SqlServer.ConnectionInfo
    // Microsoft SqlServer.Management.Sdk.Sfc
    // Microsoft SqlServer.Smo
    
    namespace SMO
    {
        class Program
        {
            static Database db;
    
            static void Main(string[] args)
            {
                Microsoft.SqlServer.Management.Smo.Server server;
    
                SqlConnection sqlConnection = new SqlConnection(@"Integrated Security=SSPI; Data Source=LOCAL");
                //build a "serverConnection" with the information of the "sqlConnection"
                Microsoft.SqlServer.Management.Common.ServerConnection serverConnection =
                  new Microsoft.SqlServer.Management.Common.ServerConnection(sqlConnection);
    
                //The "serverConnection is used in the ctor of the Server.
                server = new Server(serverConnection);
    
                db = server.Databases["TestDB"];
    
                Table tbl;
                tbl = db.Tables["Sales"];
                foreach (ForeignKey fk in tbl.ForeignKeys)
                {
                    Console.WriteLine("Foreign key {0} references table {1} and key {2}", fk.Name, fk.ReferencedTable, fk.ReferencedKey);
                } 
            }
        }
    }
