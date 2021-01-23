	public class TypeList<T> where T : class
	{
		private readonly List<Type> list = new List<Type>();
		public void Add(Type item)
		{
			if(!typeof(T).IsAssignableFrom(item))
			{
				throw new InvalidOperationException();
			}
			list.Add(item);
		}
	}
