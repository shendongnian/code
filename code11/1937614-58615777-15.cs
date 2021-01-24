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
                var summary = BenchmarkRunner.Run<Sp>();
            }
        }
    
        [SimpleJob]
        [MemoryDiagnoser]
        //[DisassemblyDiagnoser(printAsm: true, printIL: true, printSource: true, printDiff: true)]
        public class Sp
        {
            private readonly int[] spanBack = new int[100000];
            private readonly Vector<int> baseV;
            private readonly Vector<int> accV;
            public Sp()
            {
                if (spanBack.Length % Vector<int>.Count != 0) throw new Exception("Invalid array size");
                if (Vector<int>.Count == 4)
                {
                    baseV = new Vector<int>(new[] { 4, 4, 4, 4 });
                    accV = new Vector<int>(new[] { 0, 1, 2, 3, });
                }
                else if (Vector<int>.Count == 8)
                {
                    baseV = new Vector<int>(new[] { 8, 8, 8, 8, 8, 8, 8, 8 });
                    accV = new Vector<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7 });
                }
                else
                {
                    throw new Exception("Invalid vector size");
                }
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
    
            [Benchmark]
            public int[] BatchSimd()
            {
                int batchSize = Vector<int>.Count;
                var accV = this.accV;
                Span<int> buffer = spanBack.AsSpan();
                for (var i = 0; i < buffer.Length; i = i + batchSize)
                {
                    var currentSlice = buffer.Slice(i, batchSize);
                    var v = new Vector<int>(currentSlice);
                    v = v + accV;
                    accV = accV + baseV;
                    v.CopyTo(currentSlice);
                }
                return spanBack;
            }
    
            [Benchmark]
            public int[] Batch8()
            {
                Span<int> buffer = spanBack.AsSpan();
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
                Span<int> buffer = spanBack.AsSpan();
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
