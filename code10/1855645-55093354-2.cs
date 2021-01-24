    public class ProductsModel
     {
        public int ProductId {get; set;}
        public string Productname {get; set;}
        public int ProductTypeID { get; set; }
        public virtual ProductTypesModel  ProductTypes { get; set; }
        public string  ProductTypeName {get; set;}
     }
    
    public class ProductTypesModel
     {
        public int ProductTypeId {get; set;}
        public int ProductTypeName {get; set;}
     }
