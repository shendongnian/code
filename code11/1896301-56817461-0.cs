	public class Comment
	{
		public int Id { get; set; }
		public Guid UniqeId { get; set; }
		public string Content { get; set; }
		public virtual Post Post { get; set; } // relational entity
		public CommentStatus CommentStatus { get; set; }
	}
	public class CommentDto
	{
		public int Id { get; set; }
		public Guid UniqeId { get; set; }
		public string Content { get; set; }
		public Post Post { get; set; }
		public CommentStatus CommentStatus { get; set; }
		public DateTime DateCreated { get; set; }
	}
