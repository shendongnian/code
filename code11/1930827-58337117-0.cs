    public class Company
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public Company Parent { get; set; }
        [Required]
        public int CountryId { get; set; }
        [ForeignKey("CountryId ")]
        public Country Country { get; set; }
        
    }
