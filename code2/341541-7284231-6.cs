		[TestMethod]
		public void GetHashCodeDifferentKeysAreMostLikelyDifferentTest()
		{
			var key = new CompositeKey<string, int>("A", 13);
			var otherKey = new CompositeKey<string, int>("A", 14);
			Assert.AreNotEqual(key.GetHashCode(), otherKey.GetHashCode());
		}
