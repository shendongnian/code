	interface IBook {
	    string Name { get; set; }
	}
	
	public class FantasyBook : IBook
	{
		public string Name { get; set; }
		public string Genre { get; set; }
	}
	public class HorrorBook : IBook
	{
	    public string Name {get;set;}
	    public string Genre {get;set;}
	}
	
	public class BadaBook : IBook // so I added this new class that does not implement Genre to illustrate a point
	{
		public string Name { get; set; }
	}
	static void Main(string[] args)
		{
			var LordOfTheRings = new FantasyBook();
			var Frankenstein = new HorrorBook();
			var Badaboom = new BadaBook();
			Dictionary<string, dynamic> books = new Dictionary<string, dynamic>();
	
			books.Add("LOTR", LordOfTheRings);
			books.Add("Frankenstein", Frankenstein);
			books.Add("Badaboom", Badaboom);
			books["LOTR"].Name = "Lord Of The Rings";
			books["LOTR"].Genre = "Fantasy";
			books["Badaboom"].Name = "We can easily assign Name as it is defined. No problem here";
			books["Badaboom"].Genre = "But we will miserably fail here"; // RuntimeBinderException: 'UserQuery.BadaBook' does not contain a definition for 'Genre'
			
			Console.ReadLine();
		}
