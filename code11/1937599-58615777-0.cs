    using System;
    using System.Numerics;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;
    
    namespace bench
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (Vector<int>.Count != 4) throw new Exception("plop");
    
                var summary = BenchmarkRunner.Run<Sp>();
            }
        }
    
        [SimpleJob]
        [MemoryDiagnoser]
        //[DisassemblyDiagnoser(printAsm: true, printIL: true, printSource: true, printDiff: true)]
        public class Sp
        {
            private readonly int[] spanBack = new int[100000];
            public Sp()
            {
                if(spanBack.Length % 4 != 0) throw new Exception("Invalid array size");
            }
    
            [Benchmark(Baseline = true)]
            public int[] Default()
            {
                Span<int> buffer = spanBack.AsSpan();
                for (var i = 0; i < buffer.Length; i++)
                    buffer[i] = i;
    
                return spanBack;
            }
    
            [Benchmark]
            public int[] Batch4()
            {
                Span<int> buffer = spanBack.AsSpan();
                for (var i = 0; i < buffer.Length; i = i + 4)
                {
                    buffer[i + 0] = i + 0;
                    buffer[i + 1] = i + 1;
                    buffer[i + 2] = i + 2;
                    buffer[i + 3] = i + 3;
                }
    
                return spanBack;
            }
    
            private readonly Vector<int> baseV4 = new Vector<int>(new[] { 4, 4, 4, 4 });
            private readonly Vector<int> accV4 = new Vector<int>(new[] { 0, 1, 2, 3 });
    
            [Benchmark]
            public int[] Batch4Simd()
            {
                const int batchSize = 4;
                var accV = accV4;
    
                Span<int> buffer = spanBack.AsSpan();
                for (var i = 0; i < buffer.Length; i = i + batchSize)
                {
                    //accV = accV + 
                    var currentSlice = buffer.Slice(i, batchSize);
    
                    var v = new Vector<int>(currentSlice);
                    v = v + accV;
                    accV = accV + baseV4;
    
                    v.CopyTo(currentSlice);
                }
    
                return spanBack;
            }
    
            [Benchmark]
            public int[] Batch8()
            {
                //int[] spanBack = new int[1000];
                Span<int> buffer = spanBack.AsSpan(); // snipped
                for (var i = 0; i < buffer.Length; i = i + 8)
                {
                    buffer[i + 0] = i + 0;
                    buffer[i + 1] = i + 1;
                    buffer[i + 2] = i + 2;
                    buffer[i + 3] = i + 3;
                    buffer[i + 4] = i + 4;
                    buffer[i + 5] = i + 5;
                    buffer[i + 6] = i + 6;
                    buffer[i + 7] = i + 7;
                }
    
                return spanBack;
            }
    
            [Benchmark]
            public int[] Batch16()
            {
                Span<int> buffer = spanBack.AsSpan(); // snipped
                for (var i = 0; i < buffer.Length; i = i + 16)
                {
                    buffer[i + 0] = i + 0;
                    buffer[i + 1] = i + 1;
                    buffer[i + 2] = i + 2;
                    buffer[i + 3] = i + 3;
                    buffer[i + 4] = i + 4;
                    buffer[i + 5] = i + 5;
                    buffer[i + 6] = i + 6;
                    buffer[i + 7] = i + 7;
                    buffer[i + 8] = i + 8;
                    buffer[i + 9] = i + 9;
                    buffer[i + 10] = i + 10;
                    buffer[i + 11] = i + 11;
                    buffer[i + 12] = i + 12;
                    buffer[i + 13] = i + 13;
                    buffer[i + 14] = i + 14;
                    buffer[i + 15] = i + 15;
                }
    
                return spanBack;
            }
        }
    }
