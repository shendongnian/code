    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int matricule { get; set; }
        public int quantite { get; set; }
        public string email { get; set; }
        public float prix { get; set; }
        public string image { get; set; }
    }
