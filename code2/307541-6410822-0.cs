    // your connection string should be like
    // Data Source=localhost\SQLEXPRESS;Initial Catalog=YourDbName;Integrated Security=True
    var connectionString = "A connection string";
    
    var connection = new SqlConnection(connectionString);
    var query = new SqlCommand("SELECT temperature, startDate, endDate FROM yourTable", connection);
    
    connection.Open();
    var dbReader = query.ExecuteReader(CommandBehavior.Default);
    Console.WriteLine("Temperature\tTime\tDate");
    while (dbReader.Read())
    {
        var row = new object[dbReader.FieldCount];
        dbReader.GetValues(row);
    
        var temperature= row[0].ToString();
        var startDate = DateTime.Parse(row[1]);
        var endDate = DateTime.Parse(row[2]);
    
        Console.WriteLine("{0}\t{1}\t{2}", temperature, startDate, endDate);
    }
