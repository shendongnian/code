	public int MinMaxValues(string table, string column, string MinMax = "MAX")
	{
		var sql = $"select {MinMax}({column}) from {table}";
		return conn.ExecuteScalar<int>(sql); // assuming "conn" is a class level SQLiteConnection
	}
