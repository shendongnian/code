    public class IndexedWebpageWidget
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        [Required]
        public int Order { get; set; }
    
        [Required]
        [InverseProperty("Widgets")]
        public virtual Webpage Webpage { get; set; }
    
        [Required]
        [InverseProperty("Webpages")]
        public virtual Widget Widget { get; set; }
    }
