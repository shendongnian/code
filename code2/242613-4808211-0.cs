    void ExecuteFile(string connectionString, string fileName)
    {
        using(SqlConnection conn = new SqlConnection(connectionString))
        {
            string data = System.IO.File.ReadAllText(fileName);
    
            conn.Open();
    
            using(SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = data;
                cmd.ExecuteNonQuery();
            }
        }
    }
