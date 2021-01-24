    	public class DbConfig
	{
		public DbTypes DbType { get; set; }
		public string ConnectionString { get; set; }
	}
	public enum DbTypes
	{
		MsSql,
		PostgreSql,
        .....,
        ....
	}
