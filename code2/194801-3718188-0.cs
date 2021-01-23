    [TestMethod()]
        public void NextSaturdayTest()
        {
            DateTime actual = DateExtensions.NextSaturday(DateTime.Parse("2010-08-14"));
            Assert.AreEqual(DateTime.Parse("2010-08-21"), actual);
            actual = DateExtensions.NextSaturday(DateTime.Parse("2010-08-19"));
            Assert.AreEqual(DateTime.Parse("2010-08-21"), actual);
        }
