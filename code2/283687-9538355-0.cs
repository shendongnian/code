    public class Post : Model
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string UrlName { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public DateTime PostedTime { get; set; }
        public DateTime LastCommentedTime { get; set; }
        public bool IsPublished { get; set; }
    
        public Category[] Category { get; set; }
        public Comment[] Comments { get; set; }
        public Tag[] Tags { get; set; }
    }
