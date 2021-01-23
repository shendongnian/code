	class Foo
	{
		private Queue<int> queue = new Queue<int>();
	
		public Foo(IObservable<int> bar)
		{
			bar.Subscribe(n =>
			{
				lock (queue)
				{
					queue.Enqueue(n);
					if (queue.Count > 20)
					{
						queue.Dequeue();
					}
				}
			});
		}
	
		public IEnumerable<int> MostRecentBars
		{
			get 
			{
				lock (queue)
				{
					return queue.ToArray();
				}
			}
		}
	}
