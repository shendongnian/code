    public class TestResult
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public TestResult Test() {
        return new TestResult() { ID = 5, Name= "Dave" };
    }
