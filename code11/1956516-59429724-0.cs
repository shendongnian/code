        public DbSet<RefreshToken> AspNetUserRefreshTokens { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("needs a connection string");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
            modelBuilder.ApplyConfiguration(new PortalUserConfiguration()); // i suspect this piece can be your issue, check if you've got it hooked up
        }
        public class PortalUserConfiguration : IEntityTypeConfiguration<PortalUser>
        {
            public void Configure(EntityTypeBuilder<PortalUser> builder)
            {
                builder.HasOne(x => x.RefreshToken)
                    .WithOne(x => x.User)
                    .HasForeignKey<PortalUser>(x => x.RefreshTokenId)
                    .OnDelete(DeleteBehavior.SetNull);
            }
        }
        public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
        {
            public void Configure(EntityTypeBuilder<RefreshToken> builder)
            {
                builder.ToTable("AspNetUserRefreshTokens");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.Token).IsRequired();
                builder.HasOne(x => x.User).WithOne(x => x.RefreshToken)
                    .HasForeignKey<RefreshToken>(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            }
        }
    }
