    using (var sqlConnection = new SqlConnection (@"Data Source=localhost\SQLExpress;Initial Catalog=MinTest;Integrated Security=True"))
    using (var sqlCommand = sqlConnection.CreateCommand ())
    {
        sqlConnection.Open ();
        var customers = sqlCommand.Get_Customer (Id:10, CompId:20).ToArray ();
        foreach (var customer in customers)
        {
            Console.WriteLine (customer.Id);
            Console.WriteLine (customer.CompId);
            Console.WriteLine (customer.FirstName);
            Console.WriteLine (customer.LastName);
            Console.WriteLine (customer.OrgNo);
        }
        var deleteCount = sqlCommand.Delete_Customer (Id:20, CompId:20);
        Console.WriteLine ("Deleted rows: {0}", deleteCount);
        Console.ReadKey ();
    }
