    public class Post
    {
        public string AuthorId { get; set; }
        [ForiegnKey("AuthorId")]
        public AppUser Author { get; set; }
    }
