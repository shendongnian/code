    public DbSet<Incident> Incidents { get; set; }
        public DbSet<Site> Sites { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>(entity =>
            {
                entity.ToTable("Incidents");
                entity.Property(e => e.Id)
                    .HasColumnName("ID");
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.ReportedBy)
                    .IsRequired()
                    .HasMaxLength(255);
            });
            modelBuilder.Entity<Site>(entity =>
            {
                //entity.HasNoKey();
                entity.ToTable("Location");
                entity.Property(e => e.Id).HasColumnName("Code");
                entity.HasOne(s => s.Incident)
                      .WithOne(i=>i.Site)
                      .HasForeignKey<Incident>(s => s.SiteId);
            });
        }
