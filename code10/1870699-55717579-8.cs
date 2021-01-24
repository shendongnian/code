    public partial class AssigneeContext : DbContext
    {
        public AssigneeContext()
        {
        }
        public AssigneeContext(DbContextOptions<AssigneeContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Assignee> Assignee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=machine\\DEV;Initial Catalog=Spikes;uid=user;pwd=password;MultipleActiveResultSets=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
            modelBuilder.Entity<Assignee>(entity =>
            {
                entity.Property(e => e.AssigneeId).HasColumnName("AssigneeID");
            });
        }
    }
