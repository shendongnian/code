    public class MyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityId {get;set;}
    
        public string SomeNameField {get;set;}
    
        public DateTime SomeDateField {get;set;}
    }
