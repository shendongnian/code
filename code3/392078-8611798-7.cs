    class MyClass
    {
        int X;
    }
    static class Program
    {
        static void Main(string args[])
        {
            MyClass a = new MyClass();
            a.X = 40;
            Method1(a);
            Method2(a);
            Console.WriteLine(a.X.ToString()); // This will print 32
        }
        static void Method1(MyClass c)
        {
            c.X = 10;
        }
        static void Method2(MyClass c)
        {
            c.X = 32;
        }
    }
