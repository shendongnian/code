    public partial class [removed for confidentiality]Context : IdentityDbContext<ApplicationUser>
    {
        public [removed for confidentiality]Context()
        {
        }
    
        public [removed for confidentiality]Context(DbContextOptions<[removed for confidentiality]Context> options)
            : base(options)
        {
        }
    
        public virtual DbSet<Foo> Foos { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "[removed for confidentiality]");
    
            modelBuilder.Entity<Foo>(entity =>
            {
                entity.Property(e => e.FooName).IsUnicode(false);
            });
    
            OnModelCreatingPartial(modelBuilder);
        }
    
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
