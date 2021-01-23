	public static dynamic DynamicWeirdness()
	{
		dynamic ex = new ExpandoObject();
		ex.TableName = "Products";
		using (var conn = OpenConnection())
		{
			conn.ThisMethodDoesntExist();
			var cmd = CreateCommand(ex);
			cmd.Connection = conn;
		}
		Console.WriteLine("It worked!");
		Console.Read();
		return null;
	}
