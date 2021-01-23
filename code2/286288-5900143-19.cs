    #define OUTPUT       // to display the testcase results
    #define VERIFY       // to selfcheck internals and verify results
    #define SIMPLERANDOM
    // #define DEBUG        // to really traces the internals
    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public static class Q5899274
    {
        // TEST DRIVER CODE
        private const int TESTITERATIONS = 100000;
        public static int Main(string[] args)
        {
            var testcases = new [] {
                new [] {0,1,1,2,2,2,3,3,4,4,4,4,5,5,5,6,6,6,7,7,7,7,8,8,8,8,8,9,9,9,9,10},
                new [] {0,1,1,1,2,2,2,3,3,3,4,4,4,5,5,6,6,6,7,7,7,7,8,8,8,8,9,9,9,9,9,10},
                new [] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41, 42, 42, 42, },
                new [] {1,1,1,1,2,2,2,2,3,3,3,3,4,4,4,4},
            }.AsEnumerable();
    
            // // creating some very random testcases
            // testcases = Enumerable.Range(0, 10000).Select(nr => Enumerable.Range(GROUPWIDTH, _seeder.Next(GROUPWIDTH, 400)).Select(el => _seeder.Next(-40, 40)).ToArray());
    
            foreach (var testcase in testcases)
            {
                // _seeder = new Random(45); for (int i=0; i<TESTITERATIONS; i++) // for benchmarking/regression
                {
                    try
                    {
                        var output = TestOptimized(testcase);
    #if OUTPUT
                        Console.WriteLine("spread\t{0}", string.Join(", ", output));
    #endif
    #if VERIFY
                        AssertValidOutput(output);
    #endif
                    } catch(Exception e)
                    {
                        Console.Error.WriteLine("Exception for input {0}:", string.Join(", ", testcase));
                        Console.Error.WriteLine("Sequence length {0}: {1} groups and remainder {2}", testcase.Count(), (testcase.Count()+GROUPWIDTH-1)/GROUPWIDTH, testcase.Count() % GROUPWIDTH);
                        Console.Error.WriteLine("Analysis: \n\t{0}", string.Join("\n\t", InternalAnalyzeInputRuns(testcase)));
                        Console.Error.WriteLine(e);
                    }
                }
            }
    
            return 0;
        }
    
    #region Algorithm Core
        const int GROUPWIDTH = 3; /* implying a minimum distance of 2
                                     (GROUPWIDTH-1) values in between duplicates
                                     must be guaranteed*/
    
        public static T[] TestOptimized<T>(T[] input, bool doShuffle = false)
            where T: IComparable<T>
        {
            if (input.Length==0)
                return input;
    
            var runs = InternalAnalyzeInputRuns(input);
    #if VERIFY
            CanBeSatisfied(input.Length, runs); // throws NoValidOrderingExists if not
    #endif
            var transpositions = CreateTranspositionIndex(input.Length, runs);
    
            int pos = 0;
            for (int run=0; run<runs.Length; run++)
                for (int i=0; i<runs[run].runlength; i++)
                    input[transpositions[pos++]] = runs[run].value;
    
            return input;
        }
    
        private static ValueRun<T>[] InternalAnalyzeInputRuns<T>(T[] input)
        {
            var listOfRuns = new List<ValueRun<T>>();
            Array.Sort(input);
            ValueRun<T> current = new ValueRun<T> { value = input[0], runlength = 1 };
    
            for (int i=1; i<=input.Length; i++)
            {
                if (i<input.Length && input[i].Equals(current.value))
                    current.runlength++;
                else
                {
                    listOfRuns.Add(current);
                    if (i<input.Length)
                        current = new ValueRun<T> { value = input[i], runlength = 1 };
                }
            }
    
    #if SIMPLERANDOM
            var rng = new Random(_seeder.Next());
            listOfRuns.ForEach(run => run.tag = rng.Next()); // this shuffles them
    #endif
            var runs = listOfRuns.ToArray();
            Array.Sort(runs);
    
            return runs;
        }
    
        // NOTE: suboptimal performance 
        //   * some steps can be done inline with CreateTranspositionIndex for
        //   efficiency
        private class NoValidOrderingExists : Exception { public NoValidOrderingExists(string message) : base(message) { } }
        private static bool CanBeSatisfied<T>(int length, ValueRun<T>[] runs)
        {
            int groups = (length+GROUPWIDTH-1)/GROUPWIDTH;
            int remainder = length % GROUPWIDTH;
    
            // elementary checks
            if (length<GROUPWIDTH)
                throw new NoValidOrderingExists(string.Format("Input sequence shorter ({0}) than single group of {1})", length, GROUPWIDTH));
            if (runs.Length<GROUPWIDTH)
                throw new NoValidOrderingExists(string.Format("Insufficient distinct values ({0}) in input sequence to fill a single group of {1})", runs.Length, GROUPWIDTH));
    
            int effectivewidth = Math.Min(GROUPWIDTH, length);
    
            // check for a direct exhaustion by repeating a single value more than the available number of groups (for the relevant groupmember if there is a remainder group)
            for (int groupmember=0; groupmember<effectivewidth; groupmember++)
            {
                int capacity = remainder==0? groups : groups -1;
    
                if (capacity < runs[groupmember].runlength)
                    throw new NoValidOrderingExists(string.Format("Capacity exceeded on groupmember index {0} with capacity of {1} elements, (runlength {2} in run of '{3}'))",
                                groupmember, capacity, runs[groupmember].runlength, runs[groupmember].value));
            }
    
            // with the above, no single ValueRun should be a problem; however, due
            // to space exhaustion duplicates could end up being squeezed into the
            // 'remainder' group, which could be an incomplete group; 
            // In particular, if the smallest ValueRun (tail) has a runlength>1
            // _and_ there is an imcomplete remainder group, there is a problem
            if (runs.Last().runlength>1 && (0!=remainder))
                throw new NoValidOrderingExists("Smallest ValueRun would spill into trailing incomplete group");
    
            return true;
        }
    
        // will also verify solvability of input sequence
        private static int[] CreateTranspositionIndex<T>(int length, ValueRun<T>[] runs)
            where T: IComparable<T>
        {
            int remainder = length % GROUPWIDTH;
    
            int effectivewidth = Math.Min(GROUPWIDTH, length);
    
            var transpositions = new int[length];
            {
                int outit = 0;
                for (int groupmember=0; groupmember<effectivewidth; groupmember++)
                    for (int pos=groupmember; outit<length && pos<(length-remainder) /* avoid the remainder */; pos+=GROUPWIDTH)
                        transpositions[outit++] = pos;
    
                while (outit<length)
                {
                    transpositions[outit] = outit;
                    outit += 1;
                }
    
    #if DEBUG
                int groups = (length+GROUPWIDTH-1)/GROUPWIDTH;
                Console.WriteLine("Natural transpositions ({1} elements in {0} groups, remainder {2}): ", groups, length, remainder);
                Console.WriteLine("\t{0}", string.Join(" ", transpositions));
                var sum1 = string.Join(":", Enumerable.Range(0, length));
                var sum2 = string.Join(":", transpositions.OrderBy(i=>i));
                if (sum1!=sum2)
                    throw new ArgumentException("transpositions do not cover range\n\tsum1 = " + sum1 + "\n\tsum2 = " + sum2);
    #endif
            }
    
            return transpositions;
        }
    
    #endregion // Algorithm Core
    
    #region Utilities
        private struct ValueRun<T> : IComparable<ValueRun<T>>
        {
            public T value;
            public int runlength;
            public int tag;         // set to random for shuffling
    
            public int CompareTo(ValueRun<T> other) { var res = other.runlength.CompareTo(runlength); return 0==res? tag.CompareTo(other.tag) : res; }
            public override string ToString() { return string.Format("[{0}x {1}]", runlength, value); }
        }
    
        private static /*readonly*/ Random _seeder = new Random(45);
    #endregion // Utilities
    
    #region Error detection/verification
        public static void AssertValidOutput<T>(IEnumerable<T> output)
            where T:IComparable<T>
        {
            var repl = output.Concat(output.Take(GROUPWIDTH)).ToArray();
    
            for (int i=1; i<repl.Length; i++) 
                for (int j=Math.Max(0, i-(GROUPWIDTH-1)); j<i; j++)
                    if (repl[i].Equals(repl[j]))
                        throw new ArgumentException(String.Format("Improper duplicate distance found: (#{0};#{1}) out of {2}: value is '{3}'", j, i, output.Count(), repl[j]));
        }
    #endregion
    
    }
    
