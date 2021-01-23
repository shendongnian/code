    [TestClass]
    public class SampleTests
    {
        public TestContext Context { get; set; }
 
        [TestMethod]
        [DataSource(...)]
        public void Test()
        {
            var someData = Context.DataRow["SomeColumnName"].ToString();
            ...
        }
    }
