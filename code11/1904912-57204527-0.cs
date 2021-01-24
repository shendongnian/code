	public class Post : BaseEntity
	{
		public string Title { get; set; }
		public string ShortDescription { get; set; }
		public string Content { get; set; }
		public PostStatus PostStatus { get; set; }
		public int Views { get; set; }
		public virtual User User { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual Media Medias { get; set; }
	}
	public class Comment : BaseEntity
	{
		public string Content { get; set; }
		public virtual Comment ParentComment { get; set; }
		public virtual Post Post { get; set; }
		public virtual User? User { get; set; }
		public CommentStatus CommentStatus { get; set; }
	}
