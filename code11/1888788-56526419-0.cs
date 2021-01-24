        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Query<CustomerRownNum>();
        }
        public class CustomerRownNum
        {
            public long RowNum { get; set; }
            public Guid Id { get; set; }
            public string LastName { get; set; }
        }
