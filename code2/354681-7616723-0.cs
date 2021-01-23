    public class MyContextInitializer
        : DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            context.ContactTypes.Add(new ContactType { DisplayName = "Home" });
            context.ContactTypes.Add(new ContactType { DisplayName = "Mobile" });
            context.ContactTypes.Add(new ContactType { DisplayName = "Office" });
            context.ContactTypes.Add(new ContactType { DisplayName = "Fax" });
            //EF will call SaveChanges itself
        }
    }
