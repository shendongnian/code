	public class MySingleton
	{
		// note: not a thread-safe implementation
		static MySingleton instance;
		static DependencyThing thing;
		private MySingleton(DependencyThing thing)
		{
			MySingleton.thing = thing;
		}
		public static MySingleton GetMySingleton(DependencyThing thing)
		{
			if(instance == null) instance = new MySingleton(thing);
			return instance;
		}
	}
