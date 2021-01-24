    using (var transaction = dbContext.Database.BeginTransaction())
    {
        try
        {
            // Prepare POCOs to be stored
            ...
            dbContext.SaveChanges();
            transaction.Commit();
        }
        catch (Exception)
        {
            // Handle failure
        }
    }
