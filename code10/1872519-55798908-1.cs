    public class SqlRowWriter
    {
        private readonly string _connectionString;
        public SqlRowWriter(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void WriteRows(string[] rows)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                foreach (var row in rows)
                {
                    // Write each row
                }
            }
        }
    }
