		private static string testValue = "something";
		[TestMethod]
		public void TestMethod1()
		{
			Assert.AreEqual(testValue, "something");
			testValue = "something2";
		}
		[TestMethod]
		public void TestMethod2()
		{
			Assert.AreEqual(testValue, "something2");
			testValue = "something3";
		}
		[TestMethod]
		public void TestMethod3()
		{
			Assert.AreEqual(testValue, "something3");
		}
