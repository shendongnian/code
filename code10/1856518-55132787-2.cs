	public class GameLevel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public double PointsMin { get; set; }
		public double PointsMax { get; set; }
		
		public virtual ICollection<UserGameProfile> UserGameProfiles { get; set; }
	}
