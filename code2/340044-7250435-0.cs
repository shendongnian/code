    using System.Data;
    using System.Data.OleDb;
    
    namespace FTPAutomation.Utilities
    {
        public class AccessUtilities
        {
            public static void StripPasswordFromMDB(string currentPassword, string mdbFilePath)
            {
                var accessBuilder = new OleDbConnectionStringBuilder
                {
                    Provider = "Microsoft.Jet.OLEDB.4.0",
                    DataSource = mdbFilePath
                };
    
                using (var conn = new OleDbConnection(accessBuilder.ConnectionString))
                {
                    try
                    {
                        conn.Open();
    
                        return;
                    }
                    catch
                    {
                        // Do nothing, just let it fall through to try with password and exclusive open.
                    }
                }
    
                accessBuilder["Jet OLEDB:Database Password"] = currentPassword;
                accessBuilder["Mode"] = "Share Exclusive";
    
                using (var conn = new OleDbConnection(accessBuilder.ConnectionString))
                {
                    if (ConnectionState.Open != conn.State)
                    {
                        conn.Open(); // If it fails here, likely due to an actual bad password.
                    }
    
                    using (
                        var oleDbCommand =
                            new OleDbCommand(string.Format("ALTER DATABASE PASSWORD NULL [{0}]", currentPassword), conn))
                    {
                        oleDbCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }
    
