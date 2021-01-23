	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Diagnostics;
	namespace TestComplex
	{
		class Program
		{
			public struct Complex
			{
				public double R;
				public double I;
				public double ModulusSquared()
				{
					return this.R * this.R + this.I * this.I;
				}
			}
			public class ComplexComparer :
				IComparer<Complex>
			{
				public static readonly ComplexComparer Default = new ComplexComparer();
				public int Compare(Complex x, Complex y)
				{
					return x.ModulusSquared().CompareTo(y.ModulusSquared());
				}
			}
			private static void RandomComplexArray(Complex[] myArray)
			{
				// We use always the same seed to avoid differences in quicksort.
				Random r = new Random(2323);
				for (int i = 0; i < myArray.Length; ++i)
				{
					myArray[i].R = r.NextDouble() * 10;
					myArray[i].I = r.NextDouble() * 10;
				}
			}
			static void Main(string[] args)
			{
				// We perform some first operation to ensure JIT compiled and optimized everything before running the real test.
				Stopwatch sw = new Stopwatch();
				Complex[] tmp = new Complex[2];
				for (int repeat = 0; repeat < 10; ++repeat)
				{
					sw.Start();
					tmp[0] = new Complex() { R = 10, I = 20 };
					tmp[1] = new Complex() { R = 30, I = 50 };
					ComplexComparer.Default.Compare(tmp[0], tmp[1]);
					tmp.OrderByDescending(c => c.ModulusSquared()).ToArray();
					sw.Stop();
				}
				int[] testSizes = new int[] { 5, 100, 1000, 100000, 250000, 1000000 };
				for (int testSizeIdx = 0; testSizeIdx < testSizes.Length; ++testSizeIdx)
				{
					Console.WriteLine("For " + testSizes[testSizeIdx].ToString() + " input ...");
					// We create our big array
					Complex[] myArray = new Complex[testSizes[testSizeIdx]];
					double bestTime = double.MaxValue;
					// Now we execute repeatCount times our test.
					const int repeatCount = 15;
					for (int repeat = 0; repeat < repeatCount; ++repeat)
					{
						// We fill our array with random data
						RandomComplexArray(myArray);
						// Now we perform our sorting.
						sw.Reset();
						sw.Start();
						Array.Sort(myArray, ComplexComparer.Default);
						sw.Stop();
						double elapsed = sw.Elapsed.TotalMilliseconds;
						if (elapsed < bestTime)
							bestTime = elapsed;
					}
					Console.WriteLine("Array.Sort best time is " + bestTime.ToString());
					// Now we perform our test using linq
    bestTime = double.MaxValue; // i forgot this before
					for (int repeat = 0; repeat < repeatCount; ++repeat)
					{
						// We fill our array with random data
						RandomComplexArray(myArray);
						// Now we perform our sorting.
						sw.Reset();
						sw.Start();
						myArray = myArray.OrderByDescending(c => c.ModulusSquared()).ToArray();
						sw.Stop();
						double elapsed = sw.Elapsed.TotalMilliseconds;
						if (elapsed < bestTime)
							bestTime = elapsed;
					}
					Console.WriteLine("linq best time is " + bestTime.ToString());
					Console.WriteLine();
				}
				Console.WriteLine("Press enter to quit.");
				Console.ReadLine();
			}
		}
	}
