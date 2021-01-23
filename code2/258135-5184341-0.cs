    [TestClass]
    public class Overlap
    {
        List<TestData> data = new List<TestData>
        {
            new TestData { Id = 1, Min = 10, Max= 49},
            new TestData { Id =2, Min=50, Max=69},
            new TestData { Id=3, Min = 70, Max = 89}
        };
        [TestMethod]
        public void BoundaryCheck()
        {
            var mydata = new TestData { Id=4, Min=69, Max=100};
            bool fail = data.Any(d => (d.Min <= mydata.Min && d.Max >= mydata.Min) || 
                                      (d.Max >= mydata.Max && d.Min <= mydata.Max));
            Assert.IsTrue(fail);
        }
        class TestData
        {
            public int Id { get; set; }
            public int Min { get; set; }
            public int Max { get; set; }
        }
    }
