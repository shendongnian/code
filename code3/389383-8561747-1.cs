    [TestFixture]
    public class TestSample
    {
        [Test]
        public void TestSample()
        {
            var mockSum = new Mock<ISum>();
            mockSum.Setup(); // fill this what you want
            var sampleObj = new SampleObj(mockSum.Object);
            //Do Some Asserts
        }
    
    }
