        public SwagAiDbContext()
            : base("name=SwagAiDbContext")
        {
        }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<IndustrySection> IndustrySection { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyName).IsRequired();
                entity.Property(e => e.Url).IsRequired();
            });
            modelBuilder.Entity<IndustrySection>(entity =>
            {
                entity.HasKey(e => e.IndustryCode)
                    .HasName("PK_IndustryCode");
                entity.Property(e => e.IndustryCode).ValueGeneratedNever();
            });
        }
