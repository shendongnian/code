    public class Program
    {
    	public static void Main()
    	{
    		var fruits = new List<Fruit> {
    			new Fruit { Id = 1, Name = "Apple", Year = "year1", Quality = "Good", Location ="Asia"},
    			new Fruit { Id = 2, Name = "Apple", Year = "year2", Quality = "Better", Location ="Asia"},
    			new Fruit { Id = 3, Name = "Apple", Year = "year3", Quality = "Better", Location ="Asia"},
    			new Fruit { Id = 4, Name = "Apple", Year = "year1", Quality = "Best", Location ="Africa"},
    			new Fruit { Id = 5, Name = "Orange", Year = "year1", Quality = "Vad", Location ="Asia"},
    			new Fruit { Id = 6, Name = "Orange", Year = "year2", Quality = "Better", Location ="Asia"},
    			new Fruit { Id = 7, Name = "Orange", Year = "year3", Quality = "Bad", Location ="Asia"},
    		};
    		
    		var result = fruits.GroupBy(f => new { f.Year,f.Location})
                        .Select(g => new
                        {
                            Year = g.Key.Year, 
                            Location = g.Key.Location,
                            Good = g.Count(x => x.Quality == "Good"),
    						Better = g.Count(x => x.Quality == "Better"),
    						Best = g.Count(x => x.Quality == "Best"),
                        });
    		
    		foreach(var line in result) {
    			Console.WriteLine(String.Format("Year: {0} - Location: {1} - Good: {2} - Better: {3} - Best: {4}", line.Year, line.Location, line.Good, line.Better, line.Best));
    		}
    	}
    }
    
    public class Fruit
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
        public string Year { get; set; }
    	public string Quality { get; set; }
    	public string Location { get; set; }
    }
