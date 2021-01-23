	public class LogDbContext : DbContext
	{
		. . .
		[ThreadStatic]
		protected static LogDbContext current;
		public static LogDbContext Current()
		{
			if (current == null)
				current = new LogDbContext();
			return current;
		}
		. . .
	}
