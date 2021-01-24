    [TestFixture(typeof(int), "abc", "xyz")]
    public class GenericTestFixture<T>
    {
        private readonly string _aa;
        private readonly string _bb;
    
    
        public GenericTestFixture(string a, string b)
        {
            _aa = a;
            _bb = b;
        }
    
    
        [Test]
        public void Test1()
        {
            Debug.WriteLine($"aa is {_aa}, bb is {_bb}, t is {typeof(T)}");
        }
    
    
        [TestCase(1)]
        public void TestMethod(int c)
        {
            Assert.AreEqual(c, 1);
        }
    }
