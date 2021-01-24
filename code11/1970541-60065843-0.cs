    public class Blog
      {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Abstract { get; set; }
    
        public virtual ICollection<Post> Posts { get; set; }
      }
    
      public class RssEnabledBlog : Blog
      {
        public string RssFeed { get; set; }
      }
--------
    modelBuilder.Entity<Blog>()
      .Map(m => m.ToTable("Blogs"))
      .Map<RssEnabledBlog>(m => m.ToTable("RssBlogs"));
