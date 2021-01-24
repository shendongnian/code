     public class Tests
    {
        public static int i = 0;
        class First : IDisposable
        {
            public virtual void Dispose()
            {
                i += 1; Console.WriteLine("First's Dispose is called.");
            }
        }
        class Second : First
        {
            public override void Dispose()
            {
                i += 10; Console.WriteLine("Second's Dispose is called.");
                base.Dispose();
            }
        }
        class Third : Second
        {
            public override void Dispose()
            {
                i += 100; Console.WriteLine("Third's Dispose is called.");
                base.Dispose();
            }
        }
        public static void Test()
        {
            using (Third t = new Third()) {
                Console.WriteLine("Now everything will be ok, after leaving this block");
                Console.WriteLine("t object will be dispose");
            }
            Thread.Sleep(1000);
            System.GC.Collect();
            Assert.AreEqual(111, i);
        }
    }
