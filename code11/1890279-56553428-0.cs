	void Main()
	{
		var json = File.ReadAllText("C:\\pizzas.json");
	
		var obj = JsonConvert.DeserializeObject<List<PizzaToppings>>(json);
		
		foreach(var topping in obj.SelectMany(o => o.Toppings))
		{
			Console.WriteLine(topping);
		}
	}
	
	public class PizzaToppings
	{
		public List<string> Toppings {get;set;}
	}
