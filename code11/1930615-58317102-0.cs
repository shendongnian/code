    public class SO1010testContext : DbContext
    {
        public SO1010testContext (DbContextOptions<SO1010testContext> options)
            : base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }
    }
