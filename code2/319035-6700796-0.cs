    public class MyDoc
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
    
    MyDoc doc = srv["db"]["products"].FindOneByIdAs<MyDoc>(ObjectId.Parse("abcdef01234"));
