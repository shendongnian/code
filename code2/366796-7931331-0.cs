	public static class MyExtension
	{
                // Holds all functions to call
		private Dictionary<Type, Func<object, TDestination>> _MyConverter;
		
                // Initialize when the type is used the first time
		static MyExtension()
		{
			_MyConverter = new Dictionary<Type, Func<object, TDestination>>();
			// Add all functions into the dictionary
			_MyConverter[typeof(int)] = (source) => return (TDestination) (object) Convert.ToInt32 (source.ToString ());
			_MyConverter[typeof(long)] = (source) => return (TDestination) (object) Convert.ToInt64 (source.ToString ());
			_MyConverter[typeof(short)] = (source) => return (TDestination) (object) Convert.ToInt16 (source.ToString ());
		}
		public static TDestination As<TDestination> (this object source, TDestination defaultValue = default(TDestination))
		{
			if (source is TDestination)
				return (TDestination) source;
			if (source == null || DbNull.Equals(source))
				return defaultValue;
				
			Func<object, TDestination> func;
			// Check if we have a func for the desired type...
			if(_MyConverter.TryGetValue(typeof(TDestination), out func);
			{
                                // ... and call it.
				return func(source);
			}
			// Nothing suitable to find.
			throw new ArgumentException("The type " + typeof(TDestination).Name + " is not supported.");
		}
	}
