	using (SqlConnection Connection = new SqlConnection())
	{
		Connection.ConnectionString = "";
		Connection.Open();
		using (SqlCommand Command = Connection.CreateCommand())
		{
			Command.CommandText = "select 'lol' as [column] where 1 = 0";
			String Result = (String) Command.ExecuteScalar();
		}
	}
