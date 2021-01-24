    Context.Item.Add(item);
    Context.Database.OpenConnection();
    try
    {
        Context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ITEMS ON");
        Context.SaveChanges();
        Context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ITEMS OFF");
    }
    finally
    {
        Context.Database.CloseConnection();
    }
