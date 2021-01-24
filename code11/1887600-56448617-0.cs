	public IEnumerable<string> GetFileNames()
	{
         string query = "SELECT ID,textfilename FROM [somedatabase].[dbo].[temp] WITH(NOLOCK) WHERE isdone = 0 ORDER BY ID;";
         using (SqlConnection Conn= new SqlConnection(connectionString))
         {
            Conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, Conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var filename = reader.GetString(1);
						yield return filename;
                    }
                }
           }
		}
	}
