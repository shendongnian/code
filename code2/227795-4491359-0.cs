     public class ClassOne : Entity
        {
            public virtual string Title { get; set; }
    
            public virtual ClassTwo[] Tags { get; set; }
    
         }
    
        public class ClassTwo : Entity
        {
            public virtual string Title { get; set; }
        }
