           [TestMethod]
        public void TestMethod1()
        {
            Task.Run(async () =>
            {
			   // test setup
				var result = await SomeAsyncTask();
				Assert.IsTrue(result.Id != 0, "Id not changed");
            }).GetAwaiter().GetResult();
        }
