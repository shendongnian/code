    [BsonKnownTypes(typeof(Post), typeof(NewTypePost))]
    public abstract class PostBase
    {
        [BsonId]
        public string Id { get; set; }
    }
    public class Post: PostBase
    {        
        public string Message { get; set; }
    }
    public class NewTypePost: PostBase
    {
        public string Image { get; set; }
    }
