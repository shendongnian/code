	public class MyStaticClass
	{
		public static event EventHandler MyStaticPropertyChanged;
		private static string _MyStaticProperty = "Hello World!";
		public static string MyStaticProperty
		{
			get { return _MyStaticProperty; }
			set
			{
				if (_MyStaticProperty != value)
				{
					_MyStaticProperty = value;
					MyStaticPropertyChanged?.Invoke(null, EventArgs.Empty);
				}
			}
		}
	}
