	using System;
	
	static class Program
	{
		static void Test(ref object o) { GC.KeepAlive(o); }
	
		static void Main(string[] args)
		{
			object temp = args;
			Test(ref temp);
		}
	}
