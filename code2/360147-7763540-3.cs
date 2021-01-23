    [TestFixture]
    public class Tests
    {
        [Test, TestCaseSource(typeof(FilenameFactory), "FileNames")]
        public bool FileCheck(string fileName)
        {
            return File.Exists(fileName);
        }
    }
    public class FilenameFactory
    {
        public static IEnumerable FileNames
        {
            get
            {
                foreach (var filename in 
                       Directory.EnumerateFiles(Environment.CurrentDirectory))
                {
                    yield return new TestCaseData(filename).Returns(true);
                }
            }
        }
    }
