	public static void Main()
	{
		Repository r = new Repository();
		Console.WriteLine(r.AsReadOnly<GenericObject>().Count);
		r.AddElement<GenericObject>(new GenericObject { i = 2 });
		Console.WriteLine(r.AsReadOnly<GenericObject>().Count);
	}
	
	public class Repository
	{
		private Dictionary<Type, object> _references = new Dictionary<Type, object>();
	
		private void Ensure<T>()
		{
			if (!_references.ContainsKey(typeof(T)))
			{
				_references[typeof(T)] = new List<T>();
			}
		}
	
		public ReadOnlyCollection<T> AsReadOnly<T>()
		{
			this.Ensure<T>();
			return (_references[typeof(T)] as List<T>).AsReadOnly();
		}
	
		public void AddElement<T>(T obj)
		{
			this.Ensure<T>();
			(_references[typeof(T)] as List<T>).Add(obj);
		}
	
		public void RemoveElement<T>(T obj)
		{
			this.Ensure<T>();
			(_references[typeof(T)] as List<T>).Remove(obj);
		}
	}
	
	public class GenericObject
	{
		public int i = 0;
	}
