	using System;
	using System.Diagnostics;
	using System.Reflection;
	unsafe delegate void MemCpyImpl(byte* src, byte* dest, int len);
	static class Temp
	{
		//There really should be a generic CreateDelegate<T>() method... -___-
		static MemCpyImpl memcpyimpl = (MemCpyImpl)Delegate.CreateDelegate(
			typeof(MemCpyImpl), typeof(Buffer).GetMethod("memcpyimpl",
				BindingFlags.Static | BindingFlags.NonPublic));
		const int COUNT = 32, SIZE = 32 << 20;
		//Use different buffers to help avoid CPU cache effects
		static byte[]
			aSource = new byte[SIZE], aTarget = new byte[SIZE],
			bSource = new byte[SIZE], bTarget = new byte[SIZE],
			cSource = new byte[SIZE], cTarget = new byte[SIZE];
		static unsafe void TestUnsafe()
		{
			Stopwatch sw = Stopwatch.StartNew();
			fixed (byte* pSrc = aSource)
			fixed (byte* pDest = aTarget)
				for (int i = 0; i < COUNT; i++)
					memcpyimpl(pSrc, pDest, SIZE);
			sw.Stop();
			Console.WriteLine("Buffer.memcpyimpl: {0:N0} ticks", sw.ElapsedTicks);
		}
		
		static void TestBlockCopy()
		{
			Stopwatch sw = Stopwatch.StartNew();
			sw.Start();
			for (int i = 0; i < COUNT; i++)
				Buffer.BlockCopy(bSource, 0, bTarget, 0, SIZE);
			sw.Stop();
			Console.WriteLine("Buffer.BlockCopy: {0:N0} ticks",
				sw.ElapsedTicks);
		}
		
		static void TestArrayCopy()
		{
			Stopwatch sw = Stopwatch.StartNew();
			sw.Start();
			for (int i = 0; i < COUNT; i++)
				Array.Copy(cSource, 0, cTarget, 0, SIZE);
			sw.Stop();
			Console.WriteLine("Array.Copy: {0:N0} ticks", sw.ElapsedTicks);
		}
		
		static void Main(string[] args)
		{
			for (int i = 0; i < 10; i++)
			{
				TestArrayCopy();
				TestBlockCopy();
				TestUnsafe();
				Console.WriteLine();
			}
		}
	}
