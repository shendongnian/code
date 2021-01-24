	public T GetData<T>(string cmdText, Func<SqlDataReader, T> func)
	{
		using (var conn = new SqlConnection(connectionStringBuilder.ConnectionString))
		{
			using (var cmd = new SqlCommand(cmdText, conn))
			{
				var reader = cmd.ExecuteReader();
				return func(reader);
			}
		}
	}
