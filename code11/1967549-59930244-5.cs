    public class SampleContextFactory : IDesignTimeDbContextFactory<SampleContext>
    {
        public SampleContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SampleContext>();
            optionsBuilder.UseSqlServer(
                @"Server=.\;Database=db;Trusted_Connection=True;", 
                opts => opts.CommandTimeout(0)
                );
    
            return new SampleContext(optionsBuilder.Options);
        }
    }
