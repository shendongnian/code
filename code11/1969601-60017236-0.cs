     public class Definition
     {  
        [Key]
        public int Id{ get; set; }
    
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    
        [ForeignKey("ParentId")]
        public virtual Definition ParentDefinition { get; set; }
    }
