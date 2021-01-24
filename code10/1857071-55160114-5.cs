    public readonly struct LongStruct
    {
        public readonly long Primitive;
        public LongStruct(long value) => Primitive = value;
        public static LongStruct Add(in LongStruct lhs, in LongStruct rhs)
            => new LongStruct(lhs.Primitive + rhs.Primitive);
        public static LongStruct AddWithIn(LongStruct lhs, LongStruct rhs)
            => new LongStruct(lhs.Primitive + rhs.Primitive);
    }
    public readonly struct DoubleStruct
    {
        public readonly double Primitive;
        public DoubleStruct(double value) => Primitive = value;
        public static DoubleStruct Add(DoubleStruct lhs, DoubleStruct rhs)
            => new DoubleStruct(lhs.Primitive + rhs.Primitive);
        public static DoubleStruct AddWithIn(in DoubleStruct lhs, in DoubleStruct rhs)
            => new DoubleStruct(lhs.Primitive + rhs.Primitive);
    }
    public class Benchmark
    {
        [Benchmark]
        public void TestLong()
        {
            for (var i = 1000000000; i > 0; --i)
            {
                LongAdd(1, 2);
            }
        }
        [Benchmark]
        public void TestLongStruct()
        {
            var a = new LongStruct(1);
            var b = new LongStruct(2);
            for (var i = 1000000000; i > 0; --i)
            {
                LongStruct.Add(a, b);
            }
        }
        [Benchmark]
        public void TestLongStructWithIn()
        {
            var a = new LongStruct(1);
            var b = new LongStruct(2);
            for (var i = 1000000000; i > 0; --i)
            {
                LongStruct.AddWithIn(a, b);
            }
        }
        [Benchmark]
        public void TestDouble()
        {
            for (var i = 1000000000; i > 0; --i)
            {
                DoubleAdd(1, 2);
            }
        }
        [Benchmark]
        public void TestDoubleStruct()
        {
            var a = new DoubleStruct(1);
            var b = new DoubleStruct(2);
            for (var i = 1000000000; i > 0; --i)
            {
                DoubleStruct.Add(a, b);
            }
        }
        [Benchmark]
        public void TestDoubleStructWithIn()
        {
            var a = new DoubleStruct(1);
            var b = new DoubleStruct(2);
            for (var i = 1000000000; i > 0; --i)
            {
                DoubleStruct.AddWithIn(a, b);
            }
        }
        public static long LongAdd(long lhs, long rhs) => lhs + rhs;
        public static double DoubleAdd(double lhs, double rhs) => lhs + rhs;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>();
            Console.ReadLine();
        }
    }
