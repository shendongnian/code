    using System.Data.SqlClient;
    using System;
    public class DbConnection : IDisposable
    {
        public SqlConnection DbConn { get; private set; }
    
        public DbConnection()
        {
            DbConn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|delivery.mdf;Integrated Security=True;User Instance=True");
        }
    
        public void Dispose()
        {
            if (DbConn.State != System.Data.ConnectionState.Closed) {
                DbConn.Close();
            }
            DbConn.Dispose();
        }
    }
