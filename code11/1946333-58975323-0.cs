public class PlanetFilterer
{
    private readonly Dictionary<string, List<string>> lookup = new Dictionary<string, List<string>>();
	
	public PlanetFilterer(IEnumerable<(string filter, string value)> filters)
	{
		foreach (var (filter, value) in filters)
		{
			var	filterWithoutStars = filter.TrimEnd('*');
			if (!lookup.TryGetValue(filterWithoutStars, out var values))
			{
				values = new List<string>();
				lookup[filterWithoutStars] = values;
			}
			values.Add(value);
		}
	}
	
	public IReadOnlyList<string> Lookup(string planet, string location)
	{
		List<string> results;
		if (lookup.TryGetValue(planet + location, out results))
		{
			return results;	
		}
		if (lookup.TryGetValue(planet, out results))
		{
			return results;
		}
		return Array.Empty<string>();
	}
}
Usage:
var filters = new[]
{
	("examplePlanet", "defaultText0"),
	("examplePlanet*", "defaultText1"),
	("examplePlanet**", "defaultText2"),
	("examplePlanetSpecificlocationA", "specificAText0"),
	("examplePlanetSpecificlocationA*", "specificAText1"),
	("examplePlanetSpecificlocationB", "specificBText"),
};
var filterer = new PlanetFilterer(filters);
Console.WriteLine(string.Join(", ", filterer.Lookup("examplePlanet", "SpecificlocationA")));
Console.WriteLine(string.Join(", ", filterer.Lookup("examplePlanet", "SpecificlocationB")));
Console.WriteLine(string.Join(", ", filterer.Lookup("examplePlanet", "SpecificlocationC")));
[Try it online](https://dotnetfiddle.net/III0fC)
