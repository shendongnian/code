        public static Dictionary<string, int> GetTables(string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                Dictionary<string, int> TableNames = new Dictionary<string, int> ();
                foreach (DataRow row in schema.Rows)
                {
                    string tableName = row[2].ToString();
                    int countOfRows = GetNum(connectionString, tableName);
                    TableNames.Add(tableName , countOfRows);
                }
                return TableNames;
            }
        }
        public static int GetNum(string connectionString, string tableName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                //do query here 
                string query = String.Format("SELECT COUNT(*) FROM {0}", tableName);
                //result = connection -> get results from query
                //return result;
            }
        }
