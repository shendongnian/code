    public class Category
    {
         public int Id { get; set; } // Don't want to return this.
         public string Name { get; set; } // Only want to return this.
    }
    
    public class Product
    {
        public int ProductId {get;set;}
        public string Name { get; set; }
        public Category Category {get;set;}
        public int CategoryId {get;set;}
    }
