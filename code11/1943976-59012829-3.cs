    public class Article
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
    public class ArticleCreateModel
    {
        public string Title { get; set; }
        public bool SendToSubscribers { get; set; }
    }
