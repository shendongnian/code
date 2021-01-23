     public class AccDatabaseInitializer : CreateDatabaseIfNotExists<YourContect>
        {
          protected override void Seed(YourContect context)
           {
              context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('TableName', RESEED, NewSeedValue)");
               context.SaveChanges();
           }
        }
