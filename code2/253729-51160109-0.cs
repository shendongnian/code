    string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True";
    StringBuilder sb = new StringBuilder();
    using (var conn = new SqlConnection(connectionstring))
    {
        conn.Open();
        var comm = new SqlCommand("SELECT top 2 * FROM Customers", conn);
        using (var parser = new ChoJSONWriter(sb))
            parser.Write(comm.ExecuteReader());
    }
    
    Console.WriteLine(sb.ToString());
