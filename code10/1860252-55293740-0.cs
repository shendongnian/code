	class ExampleClass
	{
		private List<string> _myValue = new List<string>();
		public IEnumerable<string> MyValue
		{
			get
			{
				foreach (var s in _myValue) yield return s;
			}
		}
	}
