	using System;
	using System.Diagnostics;
	namespace NumberOfDigits
	{
		// Performance Tests:
		class Program
		{
			private static void Main(string[] args)
			{
				Console.WriteLine("\r\n.NET Core");
				RunTests_Int32();
				RunTests_Int64();
			}
			// Int32 Performance Tests:
			private static void RunTests_Int32()
			{
				Console.WriteLine("\r\nInt32");
				const int size = 100000000;
				int[] samples = new int[size];
				Random random = new Random((int)DateTime.Now.Ticks);
				for (int i = 0; i < size; ++i)
					samples[i] = random.Next(int.MinValue, int.MaxValue);
				Stopwatch sw1 = new Stopwatch();
				sw1.Start();
				for (int i = 0; i < size; ++i) samples[i].Digits_IfChain();
				sw1.Stop();
				Console.WriteLine($"IfChain: {sw1.ElapsedMilliseconds} ms");
				Stopwatch sw2 = new Stopwatch();
				sw2.Start();
				for (int i = 0; i < size; ++i) samples[i].Digits_Log10();
				sw2.Stop();
				Console.WriteLine($"Log10: {sw2.ElapsedMilliseconds} ms");
				Stopwatch sw3 = new Stopwatch();
				sw3.Start();
				for (int i = 0; i < size; ++i) samples[i].Digits_While();
				sw3.Stop();
				Console.WriteLine($"While: {sw3.ElapsedMilliseconds} ms");
				Stopwatch sw4 = new Stopwatch();
				sw4.Start();
				for (int i = 0; i < size; ++i) samples[i].Digits_String();
				sw4.Stop();
				Console.WriteLine($"String: {sw4.ElapsedMilliseconds} ms");
				// Start of consistency tests:
				Console.WriteLine("Running consistency tests...");
				bool isConsistent = true;
				// Consistency test on random set:
				for (int i = 0; i < samples.Length; ++i)
				{
					int s = samples[i];
					int a = s.Digits_IfChain();
					int b = s.Digits_Log10();
					int c = s.Digits_While();
					int d = s.Digits_String();
					if (a != b || c != d || a != c)
					{
						Console.WriteLine($"Digits({s}): IfChain={a} Log10={b} While={c} String={d}");
						isConsistent = false;
						break;
					}
				}
				// Consistency test of special values:
				samples = new int[] { int.MinValue, -1, 0, 1, int.MaxValue };
				for (int i = 0; i < samples.Length; ++i)
				{
					int s = samples[i];
					int a = s.Digits_IfChain();
					int b = s.Digits_Log10();
					int c = s.Digits_While();
					int d = s.Digits_String();
					if (a != b || c != d || a != c)
					{
						Console.WriteLine($"Digits({s}): IfChain={a} Log10={b} While={c} String={d}");
						isConsistent = false;
						break;
					}
				}
				// Consistency test result:
				if (isConsistent)
					Console.WriteLine("Consistency tests are OK");
			}
			// Int64 Performance Tests:
			private static void RunTests_Int64()
			{
				Console.WriteLine("\r\nInt64");
				const int size = 100000000;
				long[] samples = new long[size];
				Random random = new Random((int)DateTime.Now.Ticks);
				for (int i = 0; i < size; ++i)
					samples[i] = Math.Sign(random.Next(-1, 1)) * (long)(random.NextDouble() * long.MaxValue);
				Stopwatch sw1 = new Stopwatch();
				sw1.Start();
				for (int i = 0; i < size; ++i) samples[i].Digits_IfChain();
				sw1.Stop();
				Console.WriteLine($"IfChain: {sw1.ElapsedMilliseconds} ms");
				Stopwatch sw2 = new Stopwatch();
				sw2.Start();
				for (int i = 0; i < size; ++i) samples[i].Digits_Log10();
				sw2.Stop();
				Console.WriteLine($"Log10: {sw2.ElapsedMilliseconds} ms");
				Stopwatch sw3 = new Stopwatch();
				sw3.Start();
				for (int i = 0; i < size; ++i) samples[i].Digits_While();
				sw3.Stop();
				Console.WriteLine($"While: {sw3.ElapsedMilliseconds} ms");
				Stopwatch sw4 = new Stopwatch();
				sw4.Start();
				for (int i = 0; i < size; ++i) samples[i].Digits_String();
				sw4.Stop();
				Console.WriteLine($"String: {sw4.ElapsedMilliseconds} ms");
				// Start of consistency tests:
				Console.WriteLine("Running consistency tests...");
				bool isConsistent = true;
				// Consistency test on random set:
				for (int i = 0; i < samples.Length; ++i)
				{
					long s = samples[i];
					int a = s.Digits_IfChain();
					int b = s.Digits_Log10();
					int c = s.Digits_While();
					int d = s.Digits_String();
					if (a != b || c != d || a != c)
					{
						Console.WriteLine($"Digits({s}): IfChain={a} Log10={b} While={c} String={d}");
						isConsistent = false;
						break;
					}
				}
				// Consistency test of special values:
				samples = new long[] { long.MinValue, -1, 0, 1, long.MaxValue };
				for (int i = 0; i < samples.Length; ++i)
				{
					long s = samples[i];
					int a = s.Digits_IfChain();
					int b = s.Digits_Log10();
					int c = s.Digits_While();
					int d = s.Digits_String();
					if (a != b || c != d || a != c)
					{
						Console.WriteLine($"Digits({s}): IfChain={a} Log10={b} While={c} String={d}");
						isConsistent = false;
						break;
					}
				}
				// Consistency test result:
				if (isConsistent)
					Console.WriteLine("Consistency tests are OK");
			}
		}
	}
