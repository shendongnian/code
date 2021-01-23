     public class Product 
     { 
        [key]
        public int MyId { get; set; } 
        public string Name { get; set; } 
        public string CategoryId { get; set; } 
        public virtual Category Category { get; set; } 
     }
