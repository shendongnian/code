     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserRole>(userRole =>
        {
            userRole.HasKey(pr => new
            {
                pr.UserId,
                pr.RoleId,
                pr.ClientId
            });
        }
    }
 
