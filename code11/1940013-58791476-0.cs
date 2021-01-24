cs
        [TestCaseSource(nameof(TestCases))]
		public List<string> TestTransaction(MetaData data, List<string> ids, string requestedBy)
		{
			var test = new Test();
			return test.UpdateRequest(data, ids, requestedBy).GetAwaiter().GetResult();
		}
		public static IEnumerable TestCases
		{
			get
			{
				//successful
				yield return new TestCaseData(new MetaData(), new List<string> { "1", "2" }, "test").Returns(new List<string> { "test1", "test2" });
				//failed
				yield return new TestCaseData(null, new List<string> { "1", "2" }, "test").Returns(new List<string> { "test1", "test2" });
				//failed
				yield return new TestCaseData(new MetaData(), new List<string> { "1", "2" }, string.Empty).Returns(new List<string> { "test1", "test2" });
			}
		}
There a couple of points here
 - Why do you need a `List` of messages in `UpdateRequest` method? It's
   only initialized
 - Failed transaction depends on your logic, you can pass an invalid
   data which causes an exception, in code snippet I've used empty
   `Metadata` or `requestedBy`
