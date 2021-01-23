    using (SqlConnection conn = new SqlConnection())
	{
		conn.Open()
		using (SqlCommand cmd = new SqlCommand("SELECT myrow FROM mytable; SELECT otherrow FROM othertable", conn))
		{
			using (SqlDataReader reader = cmd.ExecuteReader())
			{
				// Handle first resultset here, and then when done call
				if (reader.NextResult())
				{
					// Handle second resultset here
				}
			}
		}
	}
