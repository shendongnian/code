    public partial class MyDatabase
    {
        private string _connectionString;
        public MyDatabase(string connectionString)
        {
             _connectionString = connectionString;
        }
        public void ExecuteSql(string sqlStatement)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                 conn.Open();
                 using (SqlCommand command = new SqlCommand(sqlStatement))
                 {
                      command.Connection = conn;
                      command.ExecuteNonQuery();
                 }
            }
        }
    }
