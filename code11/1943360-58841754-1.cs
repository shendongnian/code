        using (var db = new Context())
        {
            db.Categories.Add(new Category
                                  {
                                      Id = 2,
                                      Name = "test"
                                  });
    
            using (var tran = db.Database.BeginTransaction())
            {
                db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Categories ON;");
                db.SaveChanges();
                db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Categories OFF;");
            }
        }
