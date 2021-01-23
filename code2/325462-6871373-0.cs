    public static IDataReader ExecuteCommand(this IDbConnection dbConnection, 
        string query, object parameters)
    {
        // Left as an exercise
    }
    var dataReader = connection.ExecuteCommand(
        "select * from Foo where Bar = @bar and Baz = @baz",
        new { bar = "12332", baz = DateTime.Now });
