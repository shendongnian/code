     public class Post
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public bool IsDeleted { get; set; }
        public  ICollection<PostTag> PostTags { get; set; }
    }
    public class PostTag
    {
        //public int Id { get; set; }
        public int PostId { get; set; }
        public int TagId { get; set; }
        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
     public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
    }
