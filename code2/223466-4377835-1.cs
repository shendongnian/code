    public class MyClass
    {
        public static void RunTest()
        {
            var m = new MyClass().GetMethod(x => x.Test);
            Console.WriteLine("{0}", m);
            m = new MyClass().GetMethod<MyClass, Action<int>>(x => x.Test2);
            System.Console.WriteLine("{0}", m);
            Console.ReadKey();
        }
        public void Test()
        {
        }
        public void Test2(int a)
        {
        }
    }
