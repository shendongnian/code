    #define OPTIMIZE
    // #define VERBOSE
    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public static class X
    {
    	private const int TESTITERATIONS = 100000;
        public static int Main(string[] args)
        {
         // var testcase = new [] {0,1,1,2,2,2,3,3,4,4,4,4,5,5,5,6,6,6,7,7,7,7,8,8,8,8,8,9,9,9,9,10};
            var testcase = new [] {0,1,1,1,2,2,2,3,3,3,4,4,4,5,5,6,6,6,7,7,7,7,8,8,8,8,9,9,9,9,9,10};
            for (int i=0; i<TESTITERATIONS; i++)
            {
    #if OPTIMIZE
                var output = TestOptimized(testcase);
    #else
                var output = Test(testcase);
    #endif
    #if VERBOSE
                Console.WriteLine("spread\t{0}", string.Join(", ", output));
    
                var err = ErrorIndex(output);
                if (-1 != err)
                    Console.Error.WriteLine("ErrorIndex:\t\t{0} out of {1}", err, output.Length);
    #endif
            }
    
            return 0;
        }
    
        private struct ValueRun<T> : IComparable<ValueRun<T>>
        {
            public T val;
            public int count;
    
            public int CompareTo(ValueRun<T> other) { return other.count.CompareTo(count); }
        }
    
        private class ByLengthThenShuffled<T> : IComparer<ValueRun<T>>
        {
            private readonly Random _rnd;
            public ByLengthThenShuffled(int seed) { _rnd = new Random(seed); }
    
            public int Compare(ValueRun<T> a, ValueRun<T> b)
            {
                int res = a.CompareTo(b);
                return 0 == res? _rnd.Next(-1,+1) : res;
            }
        }
    
        private static readonly Random _seeder = new Random(45);
        public static T[] TestOptimized<T>(params T[] input)
            where T:IComparable<T>
        {
            if (input.Length==0)
                return input;
    
            int newseed = _seeder.Next();
    
            ValueRun<T>[] runs;
    
            {
                var listOfRuns = new List<ValueRun<T>>();
                {
                    Array.Sort(input);
                    ValueRun<T> current = new ValueRun<T> { val = input[0], count = 1 };
    
                    for (int i=1; i<=input.Length; i++)
                    {
                        if (i<input.Length && input[i].Equals(current.val))
                            current.count++;
                        else
                        {
                            listOfRuns.Add(current);
                            if (i<input.Length)
                                current = new ValueRun<T> { val = input[i], count = 1 };
                        }
                    }
                }
                runs = listOfRuns.ToArray();
                Array.Sort(runs, new ByLengthThenShuffled<T>(newseed)); // this shuffles them
            }
    
    		int pos = 0, length = runs.Length;
    		for (int iteration = 0; pos < input.Length; iteration++)
    			for (int index=0; index<length; index++)
    				unchecked
    				{
    					var run = runs[(index + length - 2) % length]; // the new `MAGIC`
    					if (iteration <    run.count)
    						input[pos++] = run.val;
    				}
    
            return input;
        }
    
        public static T[] Test<T>(params T[] input)
            where T:IComparable<T>
        {
            if (input.Length==0)
                return input;
    
            int newseed = _seeder.Next();
            var runs = input.GroupBy(i => i).Select(g => new ValueRun<T>() { val = g.Key, count = g.Count() }).ToList();
            runs.Sort(new ByLengthThenShuffled<T>(newseed)); // this shuffles them
    
            var subsequences = runs.Select(run => Enumerable.Repeat(run.val, run.count).ToArray()).ToArray().AsEnumerable();
            //MAGIC:
            subsequences = subsequences.Reverse();
            subsequences = subsequences.Take(2).Reverse().Concat(
                    subsequences.Skip(2).Reverse());
    
            return Enumerable.Range(0, runs.Max(r => r.count))
                .SelectMany(i => subsequences.SelectMany(g => g.Skip(i).Take(1)))
                .ToArray();
        }
    
        public static int ErrorIndex<T>(IEnumerable<T> output)
            where T:IComparable<T>
        {
            var repl = output.Concat(output.Take(2)).ToArray();
            for (int i=1; i<repl.Length; i++) 
                if (    repl[i].Equals(repl[i-1]) ||
                (i>1 && repl[i].Equals(repl[i-2])))
                    return i;
    
            return -1;
        }
    
        public static bool IsValid(IEnumerable<int> output)
        {
            return -1 == ErrorIndex(output);
        }
    
    }
