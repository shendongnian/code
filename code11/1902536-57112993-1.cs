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
as you explained that you need to check multiple columns:
C#
string storedNameString = String.Empty;
	string storedName2String = String.Empty;
	SqlConnection connection = new SqlConnection(this.Connection.ConnectionString);
	using (connection)
	{
		string SQLcommand = "select * FROM (VALUES(1, 'xxx', 'dddddd' ), (2, 'really long string xxxxxx','dfghdt'), (3, 'short string', 'anothercolumn long string'), (4, 'another string', 'test')) t (id, fName, fName2)";
		SqlCommand command = new SqlCommand(SQLcommand, connection);
		connection.Open();
		SqlDataReader reader = command.ExecuteReader();
		while (reader.Read())
		{
			string fName = reader.GetString(reader.GetOrdinal("fName")).ToString();
			if(fName.Length >= storedNameString.Length)
				storedNameString = fName;
			string fName2 = reader.GetString(reader.GetOrdinal("fName2")).ToString();
			if (fName2.Length >= storedName2String.Length)
				storedName2String = fName2;
		}
	}
	Console.WriteLine($"The longest string: {storedNameString}. charcount= {storedNameString.Length}");
	Console.WriteLine($"The longest string: {storedName2String}. charcount= {storedName2String.Length}");
