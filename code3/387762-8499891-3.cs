    class Program
    {
        static void Main(string[] args)
        {
            var someData = new ByteArray();
            int iterations = 1000000000;
            var multiple = new MultipleFixed();
            var single = new SingleFixed();
            // Warmup.
            for (int i = 0; i < 100; i++)
            {
                multiple.Test(ref someData);
                single.Test(ref someData);
                multiple.TestMore(ref someData);
                single.TestMore(ref someData);
            }
            // Environment.
            if (Debugger.IsAttached)
                Console.WriteLine("Debugger is attached!!!!!!!!!! This run is invalid!");
            Console.WriteLine("CLR Version: " + Environment.Version);
            Console.WriteLine("Pointer size: {0} bytes", IntPtr.Size);
            Console.WriteLine("Iterations: " + iterations);
            Console.Write("Starting run for Single... ");
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                single.Test(ref someData);
            }
            sw.Stop();
            Console.WriteLine("Completed in {0:N3}ms - {1:N2}/sec", sw.Elapsed.TotalMilliseconds, iterations / sw.Elapsed.TotalSeconds);
            Console.Write("Starting run for More Single... ");
            sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                single.Test(ref someData);
            }
            sw.Stop();
            Console.WriteLine("Completed in {0:N3}ms - {1:N2}/sec", sw.Elapsed.TotalMilliseconds, iterations / sw.Elapsed.TotalSeconds);
            Console.Write("Starting run for Multiple... ");
            sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                multiple.Test(ref someData);
            }
            sw.Stop();
            Console.WriteLine("Completed in {0:N3}ms - {1:N2}/sec", sw.Elapsed.TotalMilliseconds, iterations / sw.Elapsed.TotalSeconds);
            Console.Write("Starting run for More Multiple... ");
            sw = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                multiple.TestMore(ref someData);
            }
            sw.Stop();
            Console.WriteLine("Completed in {0:N3}ms - {1:N2}/sec", sw.Elapsed.TotalMilliseconds, iterations / sw.Elapsed.TotalSeconds);
            Console.ReadLine();
        }
    }
    unsafe struct ByteArray
    {
        public fixed byte Data[1024];
    }
    class MultipleFixed
    {
        unsafe void SetValue(ref ByteArray bytes, int index, byte value)
        {
            fixed (byte* data = bytes.Data)
            {
                data[index] = value;
            }
        }
        unsafe bool Validate(ref ByteArray bytes, int index, byte expectedValue)
        {
            fixed (byte* data = bytes.Data)
            {
                return data[index] == expectedValue;
            }
        }
        public void Test(ref ByteArray bytes)
        {
            SetValue(ref bytes, 0, 1);
            Validate(ref bytes, 0, 1);
        }
        public void TestMore(ref ByteArray bytes)
        {
            SetValue(ref bytes, 0, 1);
            Validate(ref bytes, 0, 1);
            SetValue(ref bytes, 0, 2);
            Validate(ref bytes, 0, 2);
            SetValue(ref bytes, 0, 3);
            Validate(ref bytes, 0, 3);
            SetValue(ref bytes, 0, 4);
            Validate(ref bytes, 0, 4);
            SetValue(ref bytes, 0, 5);
            Validate(ref bytes, 0, 5);
        }
    }
    class SingleFixed
    {
        unsafe void SetValue(byte* data, int index, byte value)
        {
            data[index] = value;
        }
        unsafe bool Validate(byte* data, int index, byte expectedValue)
        {
            return data[index] == expectedValue;
        }
        public unsafe void Test(ref ByteArray bytes)
        {
            fixed (byte* data = bytes.Data)
            {
                SetValue(data, 0, 1);
                Validate(data, 0, 1);
            }
        }
        public unsafe void TestMore(ref ByteArray bytes)
        {
            fixed (byte* data = bytes.Data)
            {
                SetValue(data, 0, 1);
                Validate(data, 0, 1);
                SetValue(data, 0, 2);
                Validate(data, 0, 2);
                SetValue(data, 0, 3);
                Validate(data, 0, 3);
                SetValue(data, 0, 4);
                Validate(data, 0, 4);
                SetValue(data, 0, 5);
                Validate(data, 0, 5);
            }
        }
    }
