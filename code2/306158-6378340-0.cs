    [TestMethod]
    public void TestMethod1()
    {
        var mock = new Mock<TestClass>(new object[] {null, null});
        mock.Setup(m => m.MockThis()).Returns("foo");
    
        Assert.AreEqual("foo", mock.Object.MockThis());
    }
    
    public class TestClass
    {
        public TestClass(int? foo, string bar)
        {
        }
    
        public virtual string MockThis()
        {
            return "bar";
        }
    }
