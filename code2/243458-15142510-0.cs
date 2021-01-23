        [TestMethod]
        public void TestConfig02IsSingleton()
        {
            var c1 = Configuration.Instance;
            var c2 = Configuration.Instance;
            Assert.AreSame(c1, c2);
        }
