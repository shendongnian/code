    public class CommentsThread
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public ICollection<ThreadComment> Comments { get; set; }
    }
    [Table(nameof(Chapter))]
    public class Chapter
    {
        [Key]
        [Required]
        [ForeignKey(nameof(CommentsThread))]
        public int Id { get; set; }
        public int Number { get; set; }
        public CommentsThread CommentsThread { get; set; }
    }
    [Table(nameof(BlogPost))]
    public class BlogPost
    {
        [Key]
        [Required]
        [ForeignKey(nameof(CommentsThread))]
        public int Id { get; set; }
        public string Author { get; set; }
        public CommentsThread CommentsThread { get; set; }
    }
    [Table(nameof(UserProfile))]
    public class UserProfile
    {
        [Key]
        [Required]
        [ForeignKey(nameof(CommentsThread))]
        public int Id { get; set; }
        public string Bio { get; set; }
        public CommentsThread CommentsThread { get; set; }
    }
    public class ThreadComment
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public CommentsThread CommentsThread { get; set; }
    }
