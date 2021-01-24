	private class TestResponse
	{
		public Dictionary<string, TestInner[]>[] KnownPropName { get; set; }
	}
	private class TestInner
	{
		public string KnownProp1 { get; set; }
		public string KnownProp2 { get; set; }
	}
