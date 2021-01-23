	public class MyContext : DbContext
	{
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new SongConfiguration());
		}
	}
	public class SongConfiguration : EntityTypeConfiguration<Song>
	{
		public SongConfiguration()
		{
			Ignore(p => p.PropToIgnore);
		}
	}
