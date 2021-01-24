    public abstract class MasterTemplate
    {
        [Key]
        public int Id { get; set; }
        public abstract string PluralName {get;}
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
    
    
