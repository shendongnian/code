    var cs = "....connection string from web.config....";
    
    try
    {
        SqlConnection connection = new SqlConnection(cs);
        connection.Open();
        Console.WriteLine("Good");
    }
    catch(Exception ex)
    {
        Console.WriteLine("Bad");
    }
