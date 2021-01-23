    public class theDBtoUse : DbContext
    {
        public DbSet<User> User { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(r => r.Id).HasColumnName("user_id");
            modelBuilder.Entity<User>().Property(r => r.FirstName).HasColumnName("user_firstname");
            modelBuilder.Entity<User>().Property(r => r. LastName).HasColumnName("user_lastname");
            modelBuilder.Entity<User>().Property(r => r.Street).HasColumnName("user_street ");
            modelBuilder.Entity<User>().Property(r => r.Country).HasColumnName("user_country");
    
            base.OnModelCreating(modelBuilder);
        }
    }
