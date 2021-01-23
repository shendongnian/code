    public class Foo 
    {
        // I hope your fields aren't really public...
        public string[] TestResults = new string[8];
        public string TestName;
        public Foo()
        {
            TestName = TestResults[0];
        }
    }
