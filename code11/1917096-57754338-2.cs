        public CustomerContext() : base()
        {
        }
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            string connectionString = "Server=localhost; Initial Catalog=TestCustomers;persist security info=True; Integrated Security = SSPI;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasData(
                new Customer { id = 1, Name = "Jojo", IsSubscribedToNewsletter = true} 
            );
        }
