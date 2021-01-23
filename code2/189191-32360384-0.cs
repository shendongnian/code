	public class MyContext : DbContext
	{
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Song>().Ignore(p => p.PropToIgnore);
		}
	}
