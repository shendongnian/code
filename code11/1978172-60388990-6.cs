    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    using System;
    using Ticks;
    namespace TIcks.Benchmarks {
        [MemoryDiagnoser]
        public class AllocationAndPassingBenchmarks {
            /// <summary>
            /// The number of ticks a stream should generate.
            /// </summary>
            [Params(1000, 100000, 10000000)]
            public int NumTicks { get; set; }
            /// <summary>
            /// The depth of methods that each tick should be processed through. To simulate methods calling methods.
            /// </summary>
            [Params(1, 10, 100)]
            public int MethodPassingDepth { get; set; }
            [Benchmark]
            public void TickPassedWithInParameter() {
                var stream = new TestTickStream(NumTicks);
                var tick = Tick.Empty;
                while (stream.MoveNext(ref tick)) {
                    var x = Process(tick, 0);
                }
                Tick Process(in Tick tick, int depth) {
                    return depth == MethodPassingDepth ? tick : Process(tick, depth + 1);
                }
            }
            [Benchmark]
            public void TickPassedWithNothing() {
                var stream = new TestTickStream(NumTicks);
                var tick = Tick.Empty;
                while (stream.MoveNext(ref tick)) {
                    var x = Process(tick, 0);
                }
                Tick Process(Tick tick, int depth) {
                    return depth == MethodPassingDepth ? tick : Process(tick, depth + 1);
                }
            }
            [Benchmark]
            public unsafe void TickPassedAsPointer() {
                var stream = new TestTickStream(NumTicks);
                var tick = Tick.Empty;
                while (stream.MoveNext(ref tick)) {
                    var tickPointer = new TickPointer(&tick);
                    var x = Process(tickPointer, 0);
                }
                TickPointer Process(TickPointer tickPointer, int depth) {
                    return depth == MethodPassingDepth ? tickPointer : Process(tickPointer, depth + 1);
                }
            }
            [Benchmark]
            public void AllocatedTicks() {
                var stream = new AllocatedTickStream(NumTicks);
                for (var tick = stream.MoveNext(); tick is object; tick = stream.MoveNext()) {
                    var x = Process(tick, 0);
                }
                AllocatedTick Process(AllocatedTick tick, int depth) {
                    return depth == MethodPassingDepth ? tick : ProcessSlowTick(tick, depth + 1);
                }
            }
        }
        [MemoryDiagnoser]
        public class MemberAccessBenchmarks {
            [Params(100, 1000)]
            public int AccessCount { get; set; }
            [Benchmark]
            public void AccessTickMembers() {
                double price, bid, ask, volume;
                DateTime time;
                var tick = new Tick(1, 1, 1, 1, DateTime.Now);
                for (var i = 0; i < AccessCount; i++) {
                    price = tick.Price;
                    bid = tick.Bid;
                    ask = tick.Ask;
                    volume = tick.Volume;
                    time = tick.TimeStamp;
                }
            }
            [Benchmark]
            public unsafe void AccessTickPointerMembers() {
                double price, bid, ask, volume;
                DateTime time;
                var tick = new Tick(1, 1, 1, 1, DateTime.Now);
                var tickPointer = new TickPointer(&tick);
                for (var i = 0; i < AccessCount; i++) {
                    price = tickPointer.Price;
                    bid = tickPointer.Bid;
                    ask = tickPointer.Ask;
                    volume = tickPointer.Volume;
                    time = tickPointer.TimeStamp;
                }
            }
        }
        class Program {
            static void Main(string[] args) {
                var summary1 = BenchmarkRunner.Run<AllocationAndPassingBenchmarks>();
                var summary2 = BenchmarkRunner.Run<MemberAccessBenchmarks>();
            }
        }
    }
