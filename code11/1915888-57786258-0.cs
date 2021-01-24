    public class BaseTest
    {
        private readonly string fileName;
        public BaseTest(string fileName)
        {
            this.fileName = fileName;
        }
        [ClassInitialize]
        public void Initialize()
        {
            // do your work with fileName
        }
        [TestCase]
        public void TestOutput1()
        {
            // test body
        }
        [TestCase]
        public void TestOutput2()
        {
            // test body
        }
    }
    [TestClass]
    public class TestFile1 : BaseTest
    {
        public TestFile1() : base("file1")
        {
        }
    }
    [TestClass]
    public class TestFile2 : BaseTest
    {
        public TestFile2() : base("file2")
        {
        }
    }
