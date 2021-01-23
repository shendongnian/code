	using System;
	using System.Diagnostics;
	using System.Reflection;
	unsafe delegate void MemCpyImplDelegate(byte* src, byte* dest, int len);
	static class Temp
	{
		static MemCpyImplDelegate memcpyimpl =
		(MemCpyImplDelegate)Delegate.CreateDelegate(typeof(MemCpyImplDelegate),
			typeof(Buffer).GetMethod("memcpyimpl",
			BindingFlags.Static | BindingFlags.NonPublic));
		const int COUNT = 32;
		//There really should be a generic CreateDelegate<T>() method... -___-
		static byte[]
			aSource = new byte[32 << 20],
			aTarget = new byte[aSource.Length],
			bSource = new byte[aSource.Length],
			bTarget = new byte[aSource.Length];
		static void TestUnsafe()
		{
			Stopwatch sw = Stopwatch.StartNew();
			unsafe
			{
				fixed (byte* pSrc = aSource)
				fixed (byte* pDest = aTarget)
				{
					for (int i = 0; i < COUNT; i++)
					{ memcpyimpl(pSrc, pDest, aSource.Length); }
				}
			}
			sw.Stop();
			Console.WriteLine("Elapsed ticks for Buffer.memcpyimpl: {0:N0}",
				sw.ElapsedTicks);
		}
		
		static void TestBlockCopy()
		{
			Stopwatch sw = Stopwatch.StartNew();
			sw.Start();
			for (int i = 0; i < COUNT; i++)
			{ Buffer.BlockCopy(bSource, 0, bTarget, 0, bSource.Length); }
			sw.Stop();
			Console.WriteLine("Elapsed ticks for Buffer.BlockCopy: {0:N0}",
				sw.ElapsedTicks);
		}
		
		static void TestArrayCopy()
		{
			Stopwatch sw = Stopwatch.StartNew();
			sw.Start();
			for (int i = 0; i < COUNT; i++)
			{ Array.Copy(bSource, 0, bTarget, 0, bSource.Length); }
			sw.Stop();
			Console.WriteLine("Elapsed ticks for Array.Copy: {0:N0}",
				sw.ElapsedTicks);
		}
		
		static void Main(string[] args)
		{
			TestArrayCopy();
			TestBlockCopy();
			TestUnsafe();
		}
	}
