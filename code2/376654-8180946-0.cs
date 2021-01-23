     public class Product 
     { 
        public int ProductId { get; set; } 
        public string Name { get; set; } 
        public string CategoryId { get; set; } 
        public virtual Category Category { get; set; } 
     } 
