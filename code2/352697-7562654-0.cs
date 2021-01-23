    public static dynamic DynamicWeirdness() {
		dynamic ex = new ExpandoObject ();
		ex.Query = "SELECT * FROM Products";
        using (var conn = OpenConnection()) {
            DbCommand cmd = CreateCommand(ex); // <-- DON'T USE VAR
            cmd.Connection = conn;
        }
        Console.WriteLine("It worked!");
        Console.Read();
        return null;
    }
