    public class CompanyAddress
    {   
        public string City { get; }
    
        public string AddressLine1 { get; }
    }
    public class Company
    {
        private List<CompanyAddress> addresses = new List<CompanyAddress>();
               
        public Guid Id { get; }
        
        public string Name { get; }
    
        public IEnumerable<CompanyAddress> Addresses { get => this.addresses; }
    
        public void AssignAddress(CompanyAddress address)
        {
            var exists = this.addresses.Contains(address);
    
            if (!exists)
            {
                this.addresses.Add(address);
            }
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>().OwnsMany<CompanyAddress>("Addresses", a =>
        {
            a.HasForeignKey("CompanyId");
            a.Property(ca => ca.City);
            a.Property(ca => ca.AddressLine1);
            a.HasKey("CompanyId", "City", "AddressLine1");
        });
    }
