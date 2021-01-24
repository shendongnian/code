    public class OutsourcedClassTest
    {
        private OutsourcedClass _Instance;
        [SetUp]
        public void Setup()
        {
            _Instance = new OutsourcedClass();
        }
        [Test]
        public void PostMethodTest()
        {
            string url = "foo";
            Assert.AreEqual(url, _Instance.PostMethod(url));
        }
    }
