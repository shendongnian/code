	class Foo
	{
		private int[] bars = new int[] { };
	
		public Foo(IObservable<int> bar)
		{
			bar
				.Scan<int, int[]>(
					new int[] { },
					(ns, n) =>
						ns
							.Concat(new [] { n, })
							.TakeLast(20)
							.ToArray())
				.Subscribe(ns => bars = ns);
		}
	
		public IEnumerable<int> MostRecentBars
		{
			get 
			{
				return bars;
			}
		}
	}
