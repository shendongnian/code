    public class MyDatabaseInitializer : DropCreateDatabaseAlways<MyDatabaseContext>
    {
        protected override void Seed(MyDatabaseContext context)
        {
            context.Database.ExecuteSqlCommand(@"ALTER TABLE Orders
                ADD CONSTRAINT C_Dates CHECK(EndDate > StartDate)");
        }
    }
