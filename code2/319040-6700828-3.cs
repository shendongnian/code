    class Product
    {
       [BsonId]
       public ObjectId Id { get; set; }
    
       public string Name{ get; set; }
    
       public List<Dimension> Dimensions{ get; set; }
    
    }
    var product = srv["db"]["products"].FindOneByIdAs<Product>();
    var dimentions = product.Dimensions;
