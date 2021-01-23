     public class BlogEntry
    {
        public BlogEntry()
        {
            this.Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<Comment> Comments { get; set; }
        public void addComment(Comment comment)
        {
            Comments.Add(comment);
        }
    }
