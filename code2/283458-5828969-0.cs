    public Context : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Employee>()
                        .HasRequired(e => e.SecondTeam)
                        .WithMany(t => t.SecondEmployees)
                        .HasForeignKey(e => e.FirstTeamId)
                        .WillCascadeOnDelete(false);
    
            ...
        }
    }
