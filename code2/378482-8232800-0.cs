    [ServiceContract] 
    public interface IProductService 
    { 
        [OperationContract] 
        int InsertProducts(MyListofProducts products); 
     } 
  
    [DataContract] 
    public class  MyListofProducts
    {
        [DataMember] 
        List<Product> Products { get; set; }
     }
    [DataContract] 
    public class Product 
    { 
        [DataMember] 
        public int ProductId{ get; set; } 
 
        [DataMember] 
        public string ProductName{ get; set; } 
 
        [DataMember] 
        public List<Product> Products { get; set; } 
    } 
