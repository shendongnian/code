    public interface IMyInterface
    {
        void InterfaceMethod();
    }
    public class MyClass : IMyInterface
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void InterfaceMethod()
        {
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void InstanceMethod()
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // JITting everyting:
            MyClass c = new MyClass();
            c.InstanceMethod();
            c.InterfaceMethod();
            TestInterface(c, 1);
            TestConcrete(c, 1);
            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();
            var x = watch.ElapsedMilliseconds;
            // Starting tests:
            watch = Stopwatch.StartNew();
            TestInterface(c, Int32.MaxValue - 2);
            var ms = watch.ElapsedMilliseconds;
            Console.WriteLine("Interface: " + ms);
            watch = Stopwatch.StartNew();
            TestConcrete(c, Int32.MaxValue - 2);
            ms = watch.ElapsedMilliseconds;
            Console.WriteLine("Concrete: " + ms);
        }
        static void TestInterface(IMyInterface iface, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                iface.InterfaceMethod();
            }
        }
        static void TestConcrete(MyClass c, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                c.InstanceMethod();
            }
        }
    }
