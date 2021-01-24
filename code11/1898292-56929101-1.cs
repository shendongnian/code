    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithOne()
            .HasForeignKey<Employee>(e => e.DepartmentId);
            
        }
