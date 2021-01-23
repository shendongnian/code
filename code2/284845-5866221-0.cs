    public class TestClass
    {
        public TestClass(ref string passedStr)
        {
            passedStr = "Change me";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string aString="I am what i am";
            TestClass obj = new TestClass(ref aString);
            Console.WriteLine(aString); // "Change me"
        }
    }
