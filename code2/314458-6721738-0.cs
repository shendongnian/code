	public class Article
	{
		public virtual int ArticleId { get; set; }
		public virtual string Title { get; set; }
		public virtual string Content { get; set; }
	}
	
	public class Meta : IComponent
	{
		public virtual Article Article { get; set; }
		public virtual int MetaId { get; set; }
		public virtual string Description { get; set; }
		public virtual string Keywords { get; set; }
	}
	
	
	
