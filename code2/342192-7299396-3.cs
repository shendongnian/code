	public static class Distributeds
	{
		private static readonly ConcurrentDictionary<Type, Type> pDistributedTypes = new ConcurrentDictionary<Type, Type>();
		
		public Type MakeDistributedType(Type type)
		{
			Type result;
			if (!pDistributedTypes.TryGetValue(type, out result))
			{
				if (there is at least one method that have [Distributed] attribute)
				{
					result = create a new dynamic type that inherits the specified type;
				}
				else
				{
					result = type;
				}
				pDistributedTypes[type] = result;
			}
			return result;
		}
		
		public T MakeDistributedInstance<T>()
			where T : class
		{
			Type type = MakeDistributedType(typeof(T));
			if (type != null)
			{
				// Instead of activator you can also register a constructor delegate generated at runtime if performances are important.
				return Activator.CreateInstance(type);
			}
			return null;
		}
	}
	// In your code...
	
	MyClass myclass = Distributeds.MakeDistributedInstance<MyClass>();
	myclass.Solve(...);
