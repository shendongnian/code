    public class Post
    {   
        [BsonId]
        public string Id { get; set; }
        [BsonIgnoreIfNull]     
        public string Message { get; set; } 
        [BsonIgnoreIfNull]
        public string Image { get; set; }
    }
