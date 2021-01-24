    public class RootObject
    {
    	// ...
    	public Dictionary<string, ChampionInfo> Data { get; set; }
    }
    public class ChampionInfo
    {
    	public string Version { get; set; }
    	public string Id { get; set; }
    	public int Key { get; set; }
    	public string Name { get; set; }
    	//...
    }
    // ...
	var champion = response.Data.Values.FirstOrDefault(x => x.Key == championId);
	if (champion != null)
	{
		Console.WriteLine(champion.Name + " " + championPoints);
	}
	else
	{
		Console.WriteLine("Nothing");
	}
