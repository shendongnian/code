    public class Contacts
        {
            [Key]
            public int ContactId { get; set; }
            public string ContactName { get; set; }
            [Display(Name = "Company")]
            public int? CompanyId { get; set; }
            [ForeignKey("CompanyId")]
            public Company Companies { get; set; }
        }
