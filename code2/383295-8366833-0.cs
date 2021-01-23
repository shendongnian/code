        class GroupItem<T> 
	{
		private List<T> items = new List<T>();
		
		public void Add(T value)
		{
			items.Add(value);
			
			
		}
		public T Get()
		{
		   //replace with some logic to detemine what to get
		   return items.First();
			
		}
		
	}
