    using System;
    using System.Data.Common;
    using Oracle.DataAccess.Client;
    
    namespace EntityFrameworkForOracle
    {
        internal class Test1Connection
        {
            internal void InternalTestRead()
            {
                using (var con = Database.GetLocalConnection())
                {
                    con.Open();
                    var cmd = Database.GetCommand(con);
    
                    const string sql = @"select *
                                from TESTTABLE";
    
                    cmd.CommandText = sql;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);
                    }
    
                    reader.Close();
    
                    con.Close();
                    con.Dispose();
    
                    cmd.Dispose();
                }
            }
    
        }
    
        public static class Database
        {
            private const string ProviderName = "Oracle.DataAccess.Client";
            private const string LocalConnectionString = "User Id=system;Password=XXX;Data Source=localhost:XXXX/XXXX;enlist=true;pooling=true";
    
            private static readonly DbProviderFactory Factory = DbProviderFactories.GetFactory(ProviderName);
    
            public static DbCommand GetCommand(DbConnection con)
            {
                var cmd = Factory.CreateCommand();
                if (cmd != null)
                {
                    cmd.Connection = con;
    
                    return cmd;
                }
                return null;
            }
    
            public static DbCommand GetCommand(string cmdText, DbConnection con)
            {
                var cmd = GetCommand(con);
                cmd.CommandText = cmdText;
    
                return cmd;
            }
    
            public static DbConnection GetLocalConnection()
            {
                var con = Factory.CreateConnection();
                if (con != null)
                {
                    con.ConnectionString = LocalConnectionString;
    
                    return con;
                }
                return null;
            }
    
            public static void CloseConnection(OracleConnection connection)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    
    }
