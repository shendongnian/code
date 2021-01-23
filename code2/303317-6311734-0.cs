    static void Main(string[] args)
    {
    	var riseAgainst = DeSerializer(CreateElement());
    		Console.WriteLine(string.Format("Band: {0}",riseAgainst.Name));
    		Console.WriteLine("-----------------------------");
    		Console.WriteLine(string.Format("Album: {0}",riseAgainst.Albums.First().Name));
    		Console.WriteLine("-----------------------------");
    		Console.WriteLine("Song List:\r");
    		foreach(var s in riseAgainst.Albums.First().Songs)
    		{
    			Console.WriteLine(string.Format("Song: {0}", s.Name));
    		}
    		Console.ReadLine();
    
    
    
    	static XElement CreateElement()
    	{
    		return new XElement("Artist",
    				new XElement("Name", "Rise Against"),
    				new XElement("Albums",
    					new XElement("Album",
    						new XElement("Name", "Appeal to Reason"),
    						new XElement("Songs",
    							new XElement("Song", new XElement("Name", "Hero of War")),
    							new XElement("Song", new XElement("Name", "Savior")))
    						))
    			);
    	}
    
    	static Artist DeSerializer(XElement element)
    	{
    		var serializer = new XmlSerializer(typeof(Artist));
    		return (Artist)serializer.Deserialize(element.CreateReader());
    	}
    }
    
    public class Artist
    {
    	public string Name { get; set; }
    	public List<Album> Albums { get; set; }
    }
    
    public class Album
    {
    	public string Name { get; set; }
    	public List<Song> Songs { get; set; }
    }
    
    public class Song
    {
    	public string Name { get; set; }
    }
