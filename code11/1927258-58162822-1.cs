    class Program
    {
        static void Main(string[] args)
        {
            First t = new First();
            Second s = new Second();
            t.Print = s.TestMethod;
            s.test = "change";
            s = null;
            t.Print("Hell"); // can debug and see that the function call goes through and string test is = "change"
        }
    }
    
    public class First
    {
        public string s;
        public Action<string> Print;
    }
    public class Second
    {
        public string test = "created";
        public void TestMethod (string test)
        {
            var res = "hello" + test + test;
        }
    }
