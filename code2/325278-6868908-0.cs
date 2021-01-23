    class GcTest
    {
        private Stopwatch sw = new Stopwatch();
        public GcTest()
        {
            sw.Start();
        }
        ~GcTest()
        {
            sw.Stop();
            Console.WriteLine("GcTest finalized in " + sw.ElapsedMilliseconds + " ms");
        }
    }
