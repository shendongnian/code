    public class User
        {
            [Key]
            public int Id { get; set; }
    
            public string Name { get; set; }
    
            public string Lastname { get; set; }
    
            [ForeignKey("GenericObject")]
            public int GenericObjectId { get; set; }
    
            public virtual GenericObject GenericObject { get; set; }
        }
    public class GenericObject
        {
            [Key]
            public int Id { get; set; }
    
            public string Description { get; set; }        
    
            public virtual User UserWhoGeneratedThisObject { get; set; }
        }
