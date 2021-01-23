    internal class Foo
	{
		public string Bar { get; set; }
		public int Baaz { get; set; }
		public override int GetHashCode()
		{
			return Bar.GetHashCode() - Baaz.GetHashCode();
		}
	}
