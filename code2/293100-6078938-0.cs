    class foo
    {
        static int liveFooInstances;
        public foo()
        {
            Interlocked.Increment(ref foo.liveFooInstances);
        }
        public void TestMethod()
        {
            Console.WriteLine("entering method");
            while (Interlocked.CompareExchange(ref foo.liveFooInstances, 1, 1) == 1)
            {
                Console.WriteLine("running GC.Collect");
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            Console.WriteLine("exiting method");
        }
        ~foo()
        {
            Console.WriteLine("in ~foo");
            Interlocked.Decrement(ref foo.liveFooInstances);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            foo aFoo = new foo();
            aFoo.TestMethod();
            //Console.WriteLine(aFoo.ToString()); // if this line is uncommented TestMethod will never return
        }
    }
