    public class DB
    {
        private string connectionString;
        public ServiceProxy(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<Records> GetRecords()
        {
            using (var conn = new SqlConnection(connectionString)){
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Records", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<Records> rows = new List<Records>();
                    while (reader.Read())
                    {
                        rows.Add(new Records(reader.GetString(1)));
                    }
                    return rows;
                }
            }
        }
    }
