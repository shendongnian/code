    public partial class Post
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
    }
    var result = await db.Posts.Where(x => x.BlogId == blogId && x.Blog. ... whatever you may also need).Select(x => whatever you need from here).ToArrayAsync()
