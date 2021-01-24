        public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
.
        public class ArticleDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public bool SendToSubscribers { get; set; }
    }
