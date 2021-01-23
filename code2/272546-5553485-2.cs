    #define PARALLEL
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Collections.Concurrent;
    using System.Threading.Tasks;
    namespace test
    {
    	class MainClass
    	{
    		const int _numInterations = 50000;
    		const int _dartsPerIter = 10000;
    	
    		protected static int ThrowDarts (int iterations)
    		{
    			Random random = new Random ();
    			int dartsInsideCircle = 0;
    			for (int iteration = 0; iteration < iterations; iteration++) {
    				double pointX = random.NextDouble () - 0.5;
    				double pointY = random.NextDouble () - 0.5;
    				
    				double distanceFromOrigin = Math.Sqrt (pointX * pointX + pointY * pointY);
    				bool pointInsideCircle = distanceFromOrigin <= 0.5;
    				
    				if (pointInsideCircle) {
    					dartsInsideCircle++;
    				}
    			}
    			return dartsInsideCircle;
    		}
    		protected int CountInterationsInsideCircle ()
    		{
    			ConcurrentBag<int> results = new ConcurrentBag<int> ();
    			int result = 0;
    			
    			// initialise each thread by setting it's hit count to 0
    			//in the body, we throw one dart and see whether it hit or not
    			// finally, we sum (in a thread-safe way) all the hit counts of each thread together
    #if PARALLEL
    			Parallel.For (0, _numInterations, () => 0, (iteration, state, localState) => localState + ThrowDarts (_dartsPerIter), results.Add);
    #else
    			for (var i =0; i<_numInterations; ++i)
    				results.Add(ThrowDarts (_dartsPerIter));
    #endif
    			
    			foreach (var threadresult in results) {
    				result += threadresult;
    			}
    			
    			return result;
    		}
    		public static void Main (string[] args)
    		{
    			Console.WriteLine("Yo");
    			var inside = new MainClass ().CountInterationsInsideCircle ();
    			Console.WriteLine("Approx: {0}/{1} => Pi: {2}",
    			                   inside, _numInterations * _dartsPerIter,
    			                   (4.0*inside)/(1.0*_numInterations*_dartsPerIter));
    		}
    	}
    }
