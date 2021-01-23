    public partial class ProductWrapper 
    {
         [Key]     
         public Guid Id { get; set; }     
         public string Name { get; set; }
    	 
         [Include]
         [Association("FK_ProductsWrapper", "Id", "CategoryId")]     
         public Category[] CategoryList { get; set; } 
    }
