    [TestFixture]
    class Class1
    {
        [Test]
        public void test()
        {
            var l = new List<SuperClass>();
            l.Add(new SuperClass());
            var castedList = ((List<BaseClass>)l);
        }
    }
    public class BaseClass
    {
        public string a { get; set; }
    }
    public class SuperClass : BaseClass
    {
        public string b { get; set; }
    }
