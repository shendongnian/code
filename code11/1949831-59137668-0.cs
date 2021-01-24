    public class Client 
    {
        public int Id { get; set; }
        // One warranty company client to a job.
        public int? WarrantyCompanyId { get; set; }
        public Job? WarrantyCompany { get; set; }
        public ICollection<Job> Jobs { get; set; } = default!;
        public ICollection<Job> WarrantyCompanyJobs { get; set; } = default!;
    }
