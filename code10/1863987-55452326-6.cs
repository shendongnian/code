    public class MyPolicyConfigurationProvider: ConfigurationProvider
    {
        public MyPolicyConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }
        Action<DbContextOptionsBuilder> OptionsAction { get; }
        // Load config data from EF DB.
        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<MyPoliciesContext>();
            OptionsAction(builder);
            using (var dbContext = new MyPoliciesContext(builder.Options))
            {
                var keys=FlattenRoles(dbContext.Roles);
                Data=new Dictionary<string,string>(keys);
            }
        }
    }
