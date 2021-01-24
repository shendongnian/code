	[TestClass]
	public class RandomGeneratorSpec
	{
		[TestMethod]
		public void GetRandomListMember_ListOfStrings()
		{
			List<string> strings = new List<string> { "red", "yellow", "green" }; 
			string result = RandomGenerator.GetRandomListMember(strings);
			Assert.IsTrue(strings.Contains(result));
		}
	}
