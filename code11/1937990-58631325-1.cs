	using System;
	using System.Runtime.CompilerServices;
	using System.Runtime.Intrinsics.X86;
	using System.Runtime.Intrinsics;
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Jobs;
	using BenchmarkDotNet.Running;
	namespace IntrinsicsDemo
	{
		public class Program
		{
			public static void Main(string[] args)
			{
				if (!Sse2.IsSupported)
				{
					Console.WriteLine("Your CPU doesn't support SSE2 Instruction set");
					return;
				}
				var summary = BenchmarkRunner.Run<IntrinsicsBench>();
			}
		}
		[SimpleJob]
		[MemoryDiagnoser]
		public unsafe class IntrinsicsBench
		{
			private long[] _data = new long[100000];
			private Vector128<long> _v = Vector128.Create(1L, 0L);
			private Vector128<long> _v2 = Vector128.Create(0L, 0L);
			public IntrinsicsBench()
			{
				for (var i = 0; i < _data.Length; i++)
				{
					_data[i] = 0;
				}
			}
			[Benchmark(Baseline = true)]
			public long[] Default()
			{
				for (var i = 0; i < _data.Length; i++)
				{
					_data[i] = i;
				}
				return _data;
			}
			[Benchmark]
			public long[] DefaultSpan()
			{
				var buffer = _data.AsSpan();
				for (var i = 0; i < buffer.Length; i++)
				{
					buffer[i] = i;
				}
				return _data;
			}
			[Benchmark]
			public long[] Unroll8()
			{
				var buffer = _data.AsSpan();
				for (var i = 0; i < buffer.Length; i += 8)
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
				return _data;
			}
			[Benchmark]
			public long[] Sse2Test()
			{
				unsafe
				{
					fixed (long* lp = _data)
					{
						for (int i = 0; i < _data.Length; i += 2)
						{
							Sse2.StoreAlignedNonTemporal(lp + i, _v);
							_v = Sse2.Add(_v, _v2);
						}
					}
				}
				return _data;
			}
		}
	}
