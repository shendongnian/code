csharp
public class Portfolio
{
	public string Name { get; set; }
	public Dictionary<string, Position> Positions { get; set; }
}
//this is a class used just for serialization
public class PortfolioForSerialization
{
	public string Name { get; set; }
	public Position[] Positions { get; set; }
}
public class Position
{
	public string Ticker { get; set; }
	public decimal Size { get; set; }
}
Usage:
csharp
//The portfolio class you want to work with (dictionary property)
var portfolio = new Portfolio()
{
	Name = "MyPortfolio",
	Positions = new Dictionary<string, UserQuery.Position>()
	{
		{ "AOS", new Position() { Size = 10, Ticker = "AOS"}},
		{ "ABT", new Position() { Size = 100, Ticker = "ABT"}}
	}
};
//Only used for serialization
var forSerialization = new PortfolioForSerialization()
{
	Name = portfolio.Name,
	Positions = portfolio.Positions.Select(p => p.Value).ToArray()
};
string serialized = JsonConvert.SerializeObject(forSerialization);
//On deserialization, map the array back to a dictionary
var deserializedPortfolio = JsonConvert.DeserializeObject<PortfolioForSerialization>(serialized);
//Map the serialization model back to your working model
var workingPortfolio = new Portfolio()
{
	Name = deserializedPortfolio.Name,
	Positions = deserializedPortfolio.Positions.ToDictionary(k => k.Ticker, v => v)
};
Otherwise, you're going to need to use a [custom contract resolver](https://www.newtonsoft.com/json/help/html/ContractResolver.htm).
