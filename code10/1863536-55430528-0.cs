	public class Stringifier
	{
		private Dictionary<Type, Delegate> _store
			= new Dictionary<Type, Delegate>();
	
		public void Store<T>(Func<T, string> value)
		{
			_store[typeof(T)] = value;
		}
	
		public Func<T, string> Fetch<T>()
		{
			return (Func<T, string>)_store[typeof(T)];
		}
		
		public string Fetch<T>(T value)
		{
			return this.Fetch<T>().Invoke(value);
		}
		
		public string Fetch(Type type, object value)
		{
			return (string)
			(
				typeof(Stringifier)
					.GetMethods()
					.Where(x => x.Name == "Fetch")
					.Where(x => x.IsGenericMethod)
					.Where(x => x.ReturnType == typeof(string))
					.Select(x => x.MakeGenericMethod(type))
					.First()
					.Invoke(this, new [] { value })
			);
		}		
	}
