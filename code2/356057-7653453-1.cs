    class Program
	{
		private static Dictionary<int, double> _dollarValues;
		protected static Dictionary<int, double> DollarValues
		{
			get
			{
				if (_dollarValues == null)
				{
					_dollarValues = new Dictionary<int, double>();
					_dollarValues.Add(1, 11.60);
					_dollarValues.Add(2, 11.20);
					_dollarValues.Add(3, 13.00);
					_dollarValues.Add(4, 13.60);
					_dollarValues.Add(5, 15.90);
					_dollarValues.Add(6, 16.10);
					_dollarValues.Add(7, 19.10);
					_dollarValues.Add(8, 19.10);
					_dollarValues.Add(9, 19.10);
					_dollarValues.Add(10, 21.00);
					_dollarValues.Add(11, 23.00);
				}
				return _dollarValues;
			}
		}
		private static int _maxKey = 0;
		private static void Main(string[] args)
		{
			_maxKey = DollarValues.Max(key => key.Key);
			int value = 27;
			double cost = 0; //GetCost(value); If I wanted to use recursion instead.
			while(value > 0)
			{
				int key = value >= _maxKey ? _maxKey : value;
				cost += DollarValues[key];
				value -= key;
			}
		}
                //Recursion if I had to
        public static double GetCost(int value)
		{
			double cost = 0;
			cost += 
                           value >= _maxKey ? 
                                  DollarValues[_maxKey] + GetCost(value - _maxKey) 
                                  : DollarValues[value];
			return cost;
		}
	}
