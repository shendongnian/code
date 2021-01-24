    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    
        [ForeignKey("Author")]
        public int AuthorUserId { get; set; }
        public virtual User Author { get; set; }
    
        [ForeignKey("Contributor")]
        public int ContributorUserId { get; set; }
        public virtual User Contributor { get; set; }
    }
    
    public class User
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        [InverseProperty("Author")]
        public ICollection<Post> AuthoredPosts { get; set; }
    
        [InverseProperty("Contributor")]
        public ICollection<Post> ContributedToPosts { get; set; }
    }
