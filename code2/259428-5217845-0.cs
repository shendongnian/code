    public class User  
    {     
        public string UserId { get; set; }     
        public string PasswordHash { get; set; }     
        public bool IsDisabled { get; set; }     
        public DateTime AccessExpiryDate { get; set; }     
        public bool MustChangePassword { get; set; }      
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }  
    public class Role 
    {     
        public int RoleId { get; set; }     
        public string Name { get; set; }     
        public string Description { get; set; } 
    }  
    public class Right 
    {     
        public Guid RightId { get; set; }     
        public string Name { get; set; }     
        public string Description { get; set; }      
        public int RoleId { get; set; }
        public Role Role { get; set; }
    } 
    public class TestContext : DbContext
    {
        public TestContext() : base("Entities")
        {}
        protected override void  OnModelCreating(System.Data.Entity.ModelConfiguration.ModelBuilder modelBuilder)
        {
 	        base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasRequired(r => r.Role)
                .WithMany()
                .HasForeignKey(r => r.RoleId);
            modelBuilder.Entity<Right>()
                .HasRequired(r => r.Role)
                .WithMany()
                .HasForeignKey(r => r.RoleId);
        }
    }
