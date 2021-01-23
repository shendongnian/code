    public class ConnectionHelper
    {
        public static SqlConnection GetConnection()
        {
            string connectionStr = "Data Source=MICROSOFT-JIGUO;Initial Catalog=CompanyTestDB;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionStr);
            return conn;
        }
    }
