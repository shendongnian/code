    public class Bag3DMember
    {
        [BsonId]
        [DataMember]
        [BsonElement("_id")]
        public string _Id { get; set; }
    
        [DataMember]
        [BsonElement("type")]
        public string Type { get; set; }
    
        [BsonElement("geometry")]
        public Geometry Geometry { get; set; }
    
        [BsonElement("geometry_name")]
        public string GeometryName { get; set; }
    
        [BsonElement("properties")]
        public Properties Properties { get; set; }
    
    }
