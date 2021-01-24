	class Program
	{
		static void Main(string[] args)
		{
			var rand = new Random();
			int next = rand.Next(); // uses my local Random class.
		}
	}
	class Random
	{
		public int Next() => 2;
	}
