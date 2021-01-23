    [TestFixture]
    public class Tests
    {
        static string[] FileNames = new string[] 
                        { "mary.txt", "mungo.txt", "midge.txt" };
        [Test, TestCaseSource("FileNames")]
        public void TestMethod(string fileName)
        {
            Assert.That(File.Exists(fileName));
        }
    }
