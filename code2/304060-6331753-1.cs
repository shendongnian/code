    public class Foo
    {
        // I hope your fields aren't really public...
        public string[] TestResults = new string[8];
        public string TestName
        {
            get { return TestResults[0]; }
            set { TestResults[0] = value; }
        }
    }
