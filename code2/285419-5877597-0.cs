	using (SqlConnection conn = new SqlConnection())
	{
		conn.Open()
		
		using (SqlCommand cmd = new SqlCommand("SELECT myrow FROM mytable", conn))
		{
			using (SqlDataReader reader = cmd.ExecuteReader())
			{
				// Handle first resultset here
			}
		}
		
		using (SqlCommand cmd = new SqlCommand("SELECT otherrow FROM othertable", conn))
		{
			using (SqlDataReader reader = cmd.ExecuteReader())
			{
				// Handle second resultset here
			}
		}
	}
