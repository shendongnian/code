    public class DataContextInitializer : DropCreateDatabaseAlways<YourEntityFrameworkClass> {
        protected override void Seed(DataContext context) {
            context.Users.Add(new User() { Name = "Test User 1", Email = "test@test.com" });
            context.SaveChanges();
        }
    }
