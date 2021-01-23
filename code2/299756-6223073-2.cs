    using System.Data.SqlClient;
    public class DbConnection
    {
        public SqlConnection getConnection()
        {
            SqlConnection dbConn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|delivery.mdf;Integrated Security=True;User Instance=True");
            return dbConn;
        }
    }
