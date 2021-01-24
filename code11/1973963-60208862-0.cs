    public class DbContextConfiguration : DbConfiguration
    {
        public DbContextConfiguration()
        {
            var providerInstance= SqlProviderServices.Instance;
            SqlProviderServices.TruncateDecimalsToScale = false;
            this.SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
