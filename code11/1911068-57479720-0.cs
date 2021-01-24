	public class Comment
	{
		public string Content { get; set; }
		public virtual Comment ParentComment { get; set; }
		public virtual Post Post { get; set; }
		public virtual User? User { get; set; }
		public CommentStatus CommentStatus { get; set; }
	}
	public class CommentDto
	{
		public int Id { get; set; }
		public Guid UniqeId { get; set; }
		public string Content { get; set; }
		public Comment ParentComment { get; set; }
		public CommentStatus CommentStatus { get; set; }
		public DateTime DateCreated { get; set; }
	}
