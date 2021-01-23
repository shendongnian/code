	public class Post : DynamicModel
	{
		public Post(): base("db")
		{
		   PrimaryKeyField = "PostID";
		}
	}
