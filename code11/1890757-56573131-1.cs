	public class IceCream
	{
		private List<Topping> _toppings = new List<Topping>();
		public void AddTopping(Topping topping)
		{
			_toppings.Add(topping);
		}
		public IEnumerable<Topping> Toppings { get => _toppings.ToArray(); }
		public ToppingLevel Level
		{
			get =>
				_toppings
					.OrderByDescending(x => (int)x.Level)
					.FirstOrDefault()?.Level ?? ToppingLevel.Basic;
		}
	}
