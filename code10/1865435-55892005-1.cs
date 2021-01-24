        public class DrawManagedVsDrawNative
    {
        private DrawManaged drawManaged = new DrawManaged();
        private DrawNative drawNative = new DrawNative();
        private byte[] data;
        [GlobalSetup]
        public void Setup()
        {
           // Some initialization here
        }
        [Benchmark]
        public byte[] DrawManaged() => drawManaged.Draw();
        [Benchmark]
        public byte[] DrawNative() => drawNative.Draw();
    }
