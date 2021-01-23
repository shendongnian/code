    public class Product
    {
       [BsonId]
       public ObjectId Id { get; set; }
    
       public string Name{ get; set; }
    
       public List<DimensionDoc> Dimensions{ get; set; }
    }
    
    public class DimensionDoc
    {
       public int Height { get; set; }
       public int Width { get; set; }
    
    }
    
    Product product = srv["db"]["products"].FindOneByIdAs<Product>(ObjectId.Parse("abcdef01234"));
