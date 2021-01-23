    public class Blog
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<BlogPost> Posts { get; private set; }
        public Blog()
        {
            Posts = new List<BlogPost>();
        }
    }
    public class BlogPost
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public BlogPostStatus Status { get; set; }
        public DateTime? PublishDate { get; set; }
        public Blog Blog { get; private set; }
        public BlogPost(Blog blog)
        {
            Blog = blog;
        }
    }
    public enum BlogPostStatus
    {
        WorkingDraft = 0,
        Published = 1,
        Unpublished = 2,
        Deleted = 3
    }
