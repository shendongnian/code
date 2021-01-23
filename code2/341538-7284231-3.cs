		[TestMethod]
		public void EqualsTest()
		{
			var key = new CompositeKey<string, int>("A", 13);
			var otherKey = new CompositeKey<string, int>("A", 13);
			Assert.IsTrue(key.Equals(otherKey));
		}
		[TestMethod]
		public void NotEqualsTest()
		{
			var key = new CompositeKey<string, int>("A", 13);
			var otherKey = new CompositeKey<string, int>("A", 15);
			Assert.IsFalse(key.Equals(otherKey));
		}
