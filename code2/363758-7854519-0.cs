    === test1.cs ===
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void verifyFoo()
        {
            Guid i = SharedData.TestRunId;
            ...
    
    === test2.cs ===
    [TestClass]
    public class Test2
    {
        [TestMethod]
        public void verifyBar()
        {
            Guid i = SharedData.TestRunId;
            ...
