	public class PseudoTest
	{
		IList<Guid> GeneratedGuids = new List<Guid>();
		public void SetUpTest()
		{
			GuidFactory.SetStrategy(() => 
			{
				var result = Guid.NewGuid();
				GeneratedGuids.Add(result);
				return result;
			});
		}
		public void Test()
		{
			systemUnderTest.DoSomething();
			Assert.AreEqual(GeneratedGuids.Last(), someOtherGuid);
		}
	}
