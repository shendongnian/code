	public class TestObject
	{
		public string Name { get; set; }
		public bool IsHighlighted { get; set; }
		public override string ToString()
		{
			return this.Name;
		}
	}
