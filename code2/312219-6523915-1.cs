    public class Inner
    {
        public string Name { get; set; }
    
        [BsonElement("Id")]
        public string IdStr { get; set; }
    }
