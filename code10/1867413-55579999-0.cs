	public partial class MyContext:DbContext
	{           
		public  DbSet<Country> Countries { get; set; }
		public  DbSet<State> States { get; set; }
	}
