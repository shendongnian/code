    using (AdventureWorksEntities context = new AdventureWorksEntities())
    {
        string myQuery = @"SELECT p.ProductID, p.Name FROM 
            AdventureWorksEntities.Products as p";
    
        foreach (DbDataRecord rec in new ObjectQuery<DbDataRecord>(myQuery, context))
        {
            Console.WriteLine("ID {0}; Name {1}", rec[0], rec[1]);
        }
    }
