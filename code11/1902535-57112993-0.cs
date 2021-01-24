C#
string storedString = String.Empty;
	SqlConnection connection = new SqlConnection(this.Connection.ConnectionString);
	using (connection)
	{
		string SQLcommand = "select * FROM (VALUES(1, 'xxx' ), (2, 'really long string xxxxxx'), (3, 'short string'), (4, 'another string')) t (id, fName)";
		SqlCommand command = new SqlCommand(SQLcommand, connection);
		connection.Open();
		SqlDataReader reader = command.ExecuteReader();
		while (reader.Read())
		{
			storedString = reader.Cast<IDataRecord>()
							.Where(w=> w.GetOrdinal("fName").ToString().Length == reader.Cast<IDataRecord>()
																						.Max(m => m.GetOrdinal("fName")
																						.ToString().Length))
							.Select(s=> s.GetString(1))
							.FirstOrDefault();
		}
	}
	Console.WriteLine($"The longest string: {storedString}. charcount= {storedString.Length}");
the result would be :
The longest string: really long string xxxxxx. charcount= 25
