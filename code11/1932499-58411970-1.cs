    public class MovieDbContext : DbContext
    {
        public DbSet<Image> Images {get; set;}
        public DbSet<UserExtendedInfo> UserExtendedInfos {get; set;}
    }
