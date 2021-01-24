	public enum ToppingLevel
	{
		Basic,
		Gourmet,
		Deluxe,
	}
	
	public class Topping
	{
		public string Name { get; private set; }
		public ToppingLevel Level { get; private set; }
	
		public Topping(string name, ToppingLevel level)
		{
			this.Name = name;
			this.Level = level;
		}
	}
