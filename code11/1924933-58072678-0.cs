    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public virtual ProductType ProductType { get; set; }
        [ForeignKey("Category")]
        public int SubcategoryFK { get; set; }
        public virtual SubCategory Category { get; set; }
        public decimal Price { get; set; }
        public int NumberOfItems { get; set; }
        public string ImageUrl { get; set; }
        public string IsInStock { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public List<UserProduct> UserProducts { get; set; }
    }
    public class ApplicationUser:IdentityUser
    {
        public List<UserProduct> UserProducts { get; set; }
    }
    public class UserProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
