	class Foo
	{
		private readonly List<string> _values;
		private readonly Bar _bar = new Bar();
		
		public Foo(IEnumerable<string> values)
		{
			_values = values.ToList();
		}
		[JsonConstructor]
		private Foo()
		{
			_values = new List<string>();
		}
		public IEnumerable<string> Values { get { return _values; } }
		
		public object Bar { get { return _bar; } }
	}
	public class Bar
	{
		public string Property1 { get; set; }
	}
