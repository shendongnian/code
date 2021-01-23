    public class MyThreadPool
    {
        public static void Add(Thread thread)
        {
            Console.WriteLine("Called the static method.");
        }
    }
    public class SomeOtherClass
    {
        public List<Thread> MyThreadPool { get; private set; }
        
        public SomeOtherClass()
        {
            MyThreadPool = new List<Thread>();
        }
        public void DoSomethingAmbiguous()
        {
            // To me, it would make sense for the compiler to issue a warning here,
            // as it seems rather ambiguous (to me at least). However, it doesn't,
            // which tells me the behavior is defined somewhere in the spec (I'm too lazy
            // to check).
            MyThreadPool.Add(null);
        }
    }
