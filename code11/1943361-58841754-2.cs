        using (var db = new Context())
        {
            db.Categories.Add(new Category
            {
                Id = 5,
                Name = "test"
            });
            db.Database.OpenConnection();
            try
            {
                db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Categories ON;");
                db.SaveChanges();
                db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Categories OFF;");
            }
            finally
            {
                db.Database.CloseConnection();
            }
        }
