	public class UserGameProfile 
	{
		// ...
		// ...
		public int? GameLevelId { get; set; }
		[ForeignKey("GameLevelId")]
		public virtual GameLevel GameLevel { get; set; }
	}
