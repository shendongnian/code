	public IEnumerable<T> GetData<T>(string cmdText, Func<SqlDataReader, T> func)
	{
		using (var conn = new SqlConnection(connectionStringBuilder.ConnectionString))
		{
			using (var cmd = new SqlCommand(cmdText, conn))
			{
				var reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					yield return func(reader);
				}
			}
		}
	}
