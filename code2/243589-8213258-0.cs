    IDbConnection connection = new SqlConnection("Data Source=.;Initial Catalog=TestB;Integrated Security=SSPI");
    
    connection.Open();
    
    using (new DifferentDatabaseScope(connection))
    
    {
    
        TestTableDatabaseA test3 = TestTableDatabaseA.Find(1);
    
        Console.WriteLine(test3.Title);
    
    }
