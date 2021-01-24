    [Table("branch")]
    public class Branch
    {
        public long BranchId { get; set; }
    
        public string BranchName { get; set; }
    
        public long OrganisationId { get; set; }
    }
    public class BranchComposite
    {
        public Branch Branch { get; set; }
        [ForeignKey("OrganisationId")]
        public Organisation Organisation { get; set; }
    }
