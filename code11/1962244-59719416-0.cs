    //  https://docs.microsoft.com/en-us/sql/relational-databases/server-management-objects-smo/create-program/connecting-to-an-instance-of-sql-server?view=sql-server-ver15#connecting-to-an-instance-of-sql-server-by-using-sql-server-authentication-in-visual-c
    
    //// compile with:   
    // /r:Microsoft.SqlServer.Smo.dll  
    // /r:Microsoft.SqlServer.ConnectionInfo.dll  
    // /r:Microsoft.SqlServer.Management.Sdk.Sfc.dll   
    
    using System;
    using System.Linq;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    
    namespace SMOConsoleApp
    {
        class Program
        {
            static void Main()
            {
    
                // For remote connection, remote server name / ServerInstance needs to be specified  
                ServerConnection srvConn2 = new ServerConnection("machinename"/* <--default sql instance on machinename*/);  // or (@"machinename\sqlinstance") for named instances
                srvConn2.LoginSecure = false;
                srvConn2.Login = "sql_login_goes_here";
                srvConn2.Password = "password_goes_here";
                Server srv3 = new Server(srvConn2);
    
                Console.WriteLine("servername:{0} ---- version:{1}", srv3.Name, srv3.Information.Version);   // connection is established  
                Console.WriteLine(srv3.ConnectionContext); //check connection context
    
                ScriptingOptions scriptoptions = new ScriptingOptions();
                scriptoptions.ScriptSchema = true;
                scriptoptions.ScriptData = true;
                scriptoptions.ScriptDrops = false;
    
                Database mydb = srv3.Databases["master"];
                /*
                    --execute this in ssms, in the master db
                    select *
                    into dbo.testsysobjects
                    from sys.objects
                */
                Table mytable = mydb.Tables["testsysobjects", "dbo"];
    
                Console.WriteLine("database: {0} ---- table: {1} ---- rowcount: {2}", mytable.Parent.Name, mytable.Name, mytable.RowCount); //check table
    
                string scriptData = String.Join("\r\n", mytable.EnumScript(scriptoptions).ToList());
    
                Console.Write(scriptData);
    
                srvConn2.Disconnect();
    
            }
        }
    }
 
