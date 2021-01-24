    public class Products
     {
        public int ProductId {get; set;}
        public string Productname {get; set;}
        public int ProductTypeID { get; set; }
    
        [ForeignKey("ProductTypeID")]
        public virtual ProductTypes ProductTypes { get; set; }
     }
    public class ProductTypes
     {
        public int ProductTypeId {get; set;}
        public int ProductTypeName {get; set;}
     }
