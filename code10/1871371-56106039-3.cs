	public class FooBar
	{
		public int FooID { get; set; }
		public string FooProperty1 { get; set; }
		public List<Bar> Bars { get; set; }
	}
	
	public class Bar
	{
		public string BarID { get; set; } // you originally had this as int
		public string BarProperty1 { get; set; }
		public string BarProperty2 { get; set; }
		public string BarProperty3 { get; set; }
	}
