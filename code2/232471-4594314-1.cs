    public class Address
    {
        [BsonId]
        public string _id { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
    }
