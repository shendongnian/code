        [TestMethod]
        public void TestMethod1()
        {
            var sites = new List<string> {"yahoo.com", "http://yahoo.com", "http://www.yahoo.com"};
            var result = sites.Select(
                s =>
                s.StartsWith("http://www.")
                    ? s
                    : s.StartsWith("http://") 
                          ? "http://www." + s.Substring(7) 
                          : "http://www." + s).Distinct();
            Assert.AreEqual(1, result.Count());
        }
