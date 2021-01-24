     class1{
        [key]
        public string id1 {get; set;}
        
        [Key]
        public string key2 {get; set;}
        }
        
        class2{
        
        public string id1 { get; set;}
        
        public string key2 { get; set;}
        
          [ForeignKey("id1,key2")] // <= the composite FK
          public virtual class1 class1{ get; set; }
        
        }
