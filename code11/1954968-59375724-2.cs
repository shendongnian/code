          [TestMethod]
        public async Task TestMethod1()
        {
		   // test setup
			var result = await SomeAsyncMethod();
			Assert.IsTrue(result.Id != 0, "Id not changed");
        }
