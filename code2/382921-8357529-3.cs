    static class TestClass {
        static void Main(string[] args) {
            Object o = "Previous value";
            Test(ref o);
            Console.WriteLine(o);
            Console.ReadLine();
        }
        static public void Test<T>(ref T obj) {
            Object o = (Object)obj;
            Test2(ref o);
        }
        static public void Test2(ref object s) {
            if (s.GetType().Equals(typeof(String))) {
                s = "Hello world!";
            }
        }
    }
