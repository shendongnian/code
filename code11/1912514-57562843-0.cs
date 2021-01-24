    public class MyCustomConstributor : IDataSeedContributor
    {
        private readonly IIdentityDataSeeder _identityDataSeeder;
        public IdentityDataSeedContributor(IIdentityDataSeeder identityDataSeeder)
        {
            _identityDataSeeder = identityDataSeeder;
        }
        public Task SeedAsync(DataSeedContext context)
        {
            return _identityDataSeeder.SeedAsync(
                context["AdminEmail"] as string ?? "my@admin-email",
                context["AdminPassword"] as string ?? "my-admin-password",
                context.TenantId
            );
        }
    }
