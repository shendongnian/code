    public class UserGames
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string GameId { get; set; }
    }
