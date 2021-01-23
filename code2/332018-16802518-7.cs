    public class MyContext : DbContext {
        protected override void OnModelCreating(DbModelBuilder builder) {
            // Primary keys
            builder.Entity<User>().HasKey(q => q.UserID);
            builder.Entity<Email>().HasKey(q => q.EmailID);
            builder.Entity<UserEmail>().HasKey(q => 
                new { 
                    q.UserID, q.EmailID
                });
            // Relationships
            builder.Entity<UserEmail>()
                .HasRequired(t => t.Email)
                .WithMany(t => t.UserEmails)
                .HasForeignKey(t => t.EmailID)
            builder.Entity<UserEmail>()
                .HasRequired(t => t.User)
                .WithMany(t => t.UserEmails)
                .HasForeignKey(t => t.UserID)
        }
    }
