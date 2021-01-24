    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<CommentsThread> CommentsThreads { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<ThreadComment> ThreadComments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Chapter>().ToTable(nameof(Chapter));
            modelBuilder.Entity<BlogPost>().ToTable(nameof(BlogPost));
            modelBuilder.Entity<UserProfile>().ToTable(nameof(UserProfile));
        }
    }
