    public class TestPackage
    {
        public List<TestCase> testCase = new List<TestCase>();
    }
    public class TestCase
    {
        public IEnumerable<string> Categories { get; private set; }
    }
    TestPackage testpackage = new TestPackage();
    var result = testpackage.testCase.GroupBy(rs => rs.Categories);
