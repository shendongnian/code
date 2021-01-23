    public class Class1
    {
        public static void foo(bool a, bool b)
        {
            int x = 100;
            if (a)
                Console.WriteLine("statement a");
            else
                x -= 50;
            if (b)
                Console.WriteLine("statement c");
            else
                x -= 50;
            double y = 10 / x;
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class1.foo(true, true);
            Class1.foo(true, false);
            Class1.foo(false, true);
        }
    }
