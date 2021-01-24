	public async Task ProcessFile(string fileName)
	{
         string query = "Update [somedatabase].[dbo].[temp]  SET isdone=1 where filename=@fileName";
         using (SqlConnection Conn= new SqlConnection(connectionString))
         {
            Conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, Conn))
            {
				cmd.Parameters.AddWithValue("@fileName", fileName);
                await cmd.ExecuteNonQueryAsync();
           }
		}
	}
