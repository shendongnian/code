    public class MySingleton
	{
		private static readonly MySingleton _instance = new MySingleton();
		private MySingleton()
		{
			// ... read config
		}
		public static MySingleton Instance
		{
			get { return _instance; }
		}
	}
