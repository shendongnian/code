		[TestMethod]
		public void GetHashCodeSameKeysAreSameTest()
		{
			var key = new CompositeKey<string, int>("A", 13);
			var otherKey = new CompositeKey<string, int>("A", 13);
			Assert.AreEqual(key.GetHashCode(), otherKey.GetHashCode());
		}
