	string myName = "Foo Bar";
	using (MySqlConnection conn = new MySqlConnection("your connection string here"))
	{
		using (MySqlCommand cmd = conn.CreateCommand())
		{
			conn.Open();
			cmd.CommandText = @"SELECT * FROM players WHERE name = ?Name;";
			cmd.Parameters.AddWithValue("Name", myName);
			MySqlDataReader Reader = cmd.ExecuteReader();
			if (!Reader.HasRows) return;
			while (Reader.Read())
			{
				Console.WriteLine(GetDBString("column1", Reader);
				Console.WriteLine(GetDBString("column2", Reader);
			}
			Reader.Close();
			conn.Close();
		}
	}
	
	private string GetDBString(string SqlFieldName, MySqlDataReader Reader)
	{
		return Reader[SqlFieldName].Equals(DBNull.Value) ? String.Empty : Reader.GetString(SqlFieldName);
	}
