    class MyContext : DbContext
    {
        public DbSet<Customer_Values> Customer_Value { get; set; }
        public DbSet<Customer_Attributes> Customer_Attribute { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer_Attributes>()
                .HasOne(v => v.Customer_Values)
                .WithOne(a => a.Customer_Attributes)
                .HasForeignKey(v => v.AttributeId)
                .HasConstraintName("FK_Constraint_Name_Here");
        }
    }
