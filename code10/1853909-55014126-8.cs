	public class MainViewModel : ViewModelBase
	{
		public ObservableCollection<PriceLevel> PriceLevels { get; } = new ObservableCollection<PriceLevel>
		{
			new PriceLevel(110.98, new int[]{ }, new int[]{ }),
			new PriceLevel(110.97, new int[]{ }, new int[]{ }),
			new PriceLevel(110.96, new int[]{ }, new int[]{ }),
			new PriceLevel(110.95, new int[]{ }, new int[]{ 5 }),
			new PriceLevel(110.94, new int[]{ }, new int[]{ 3, 8 }),
			new PriceLevel(110.93, new int[]{ 8, 3, 5, }, new int[]{ }),
			new PriceLevel(110.92, new int[]{ 3 }, new int[]{ }),
			new PriceLevel(110.91, new int[]{ }, new int[]{ }),
		};
	}
	public class PriceLevel
	{
		public double Price { get; }
		public ObservableCollection<int> BuyOrders { get; }
		public ObservableCollection<int> SellOrders { get; }
		public PriceLevel(double price, IEnumerable<int> buyOrders, IEnumerable<int> sellOrders)
		{
			this.Price = price;
			this.BuyOrders = new ObservableCollection<int>(buyOrders);
			this.SellOrders = new ObservableCollection<int>(sellOrders);
		}
	}
