    [TestFixture]
    class Class1
    {
        [Test]
        public void test()
        {
            var list = new List<SuperClass>();
            list.Add(new SuperClass());
            var castedList = ((List<BaseClass>)list);
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
