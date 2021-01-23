    [TestClass]
    public class MyTests
    {
        private StringBuilder output;
        private StringWriter tempOutputWriter;
        private TextWriter originalOutputWriter;
        [TestInitialize]
        public void InitializeTest()
        {
            this.originalOutputWriter = Console.Out;
            this.tempOutputWriter = new StringWriter();
            Console.SetOut(tempOutputWriter);
            this.output = tempOutputWriter.GetStringBuilder();
        }
        [TestCleanup]
        public void CleanupTest()
        {
            Console.SetOut(originalOutputWriter);
            this.tempOutputWriter.Dispose();
        }
        [TestMethod]
        public void Test1()
        {
            Program.Main(new string[] { "1", "2", "3" });
            string output = this.output.ToString();
            ...
            this.output.Clear();
        }
        [TestMethod]
        public void Test2()
        {
            Program.Main(new string[] { "4", "5", "6" });
            string output = this.output.ToString();
            ...
            this.output.Clear();
        }
    }
