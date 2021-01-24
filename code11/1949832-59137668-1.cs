    public class Job
    {
        public int Id { get; set; }
        public int? WarrantyCompanyId { get; set; }
        public Client? WarrantyCompany { get; set; }
        public int ClientId { get; set; } = default!;
        public Client Client { get; set; } = default!;
    }
