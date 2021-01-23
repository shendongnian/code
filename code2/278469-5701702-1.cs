    public class MyInitializer : CreateDatabaseIfNotExists<MyContext>
    {
      protected override void Seed(MyContext context)
      {
        context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX IX_Category_Title ON Categories (Title)");
      }
    }
