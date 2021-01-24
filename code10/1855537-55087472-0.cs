    public class Actor
    { 
    	public string Name { get; set; }
    	public int Awards { get; set; }
    	public int BirthYear { get; set; }
    
    	public override int GetHashCode() => 0;
    
    	public override bool Equals(object obj) =>(obj as Actor)?.Name.Equals(this.Name) ?? base.Equals(obj);
    }
    
    
    public IEnumerable<Actor> GetActorsAndAwards(XDocument xml)
    {
    	foreach (var actor in xml.XPathSelectElements(@"//actors/actor"))
    	{
    		yield return new Actor
    		{
    			Name = $"{actor.Element("first-name").Value}, {actor.Element("last-name").Value}",
    			Awards = actor.XPathSelectElements(@"awards/award").Count(),
    			BirthYear = int.Parse(actor.Element("year-of-birth").Value)
    		};
    	};
    }
    
    public IEnumerable<Actor> AggregateAndFilter(IEnumerable<Actor> actors, int yearOfBirth, int amountOfAwards)
    	=> actors
    		.GroupBy(x => x.Name)
    		.Select(x => new Actor { Name = x.Key, BirthYear = x.First().BirthYear, Awards = x.Sum(y => y.Awards) })
    		.Where(x => x.BirthYear > yearOfBirth && x.Awards > amountOfAwards)
    		;
    		
    
    void Main()
    {
    	var xml = XDocument.Load(@"D:\Temp\0\netflix.xml");
    	
    	AggregateAndFilter(GetActorsAndAwards(xml), 1970, 2).Count().Dump(); //Dump is LinqPad tool, do whatever you want with the result
    }
