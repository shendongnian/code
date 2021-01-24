    public class MasterTemplate
    {
        [Key]
        public int Id { get; set; }
    
        [StringLength(50)]
        public virtual string Code { get; set; }
    
        [Required]
        [StringLength(255)]
        public virtual string Description { get; set; }
    
        public virtual decimal? SortOrder { get; set; }
    }
    
    public class Nationality : MasterTemplate
    {
        // Code will not appear in Nationality table
        [NotMapped]
        public override string Code { get; set; }
    }
    
    public class Zone : MasterTemplate
    {
        // Description will not appear in Zone table
        [NotMapped]
        public override string Description { get; set; }
    }
