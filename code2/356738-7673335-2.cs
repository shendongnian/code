	using System;
	using System.Linq;
	using System.Threading.Tasks;
	public class Program
	{
		static readonly double sqrt5 = Math.Sqrt(5);
		static readonly double p1 = (1 + sqrt5) / 2;
		static readonly double p2 = -1 * (p1 - 1);
		static ulong Fib1(int n) // surprisingly slightly slower than Fib2
		{
			double n1 = Math.Pow(p1, n+1);
			double n2 = Math.Pow(p2, n+1);
			return (ulong)((n1-n2)/sqrt5);
		}
		static ulong Fib2(int n) // 40x faster than Fib3
		{
			double n1 = 1.0;
			double n2 = 1.0;
			for (int i=0; i<n+1; i++)
			{
				n1*=p1;
				n2*=p2;
			}
			return (ulong)((n1-n2)/sqrt5);
		}
		static ulong Fib3(int n) // that's fast! Done in 1.32s
		{
			double n1 = 1.0;
			double n2 = 1.0;
			Parallel.For(0,n+1,(x)=> {
				n1 *= p1; 
				n2 *= p2; 
			});
			return (ulong)((n1-n2)/sqrt5);
		}
		public static void Main(string[] args)
		{
			for (int j=0; j<100000; j++)
				for (int i=0; i<90; i++)
					Fib1(i);
			for (int i=0; i<90; i++)
				Console.WriteLine(Fib1(i));
		}
	}
