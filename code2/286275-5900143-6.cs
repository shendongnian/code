    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public static class X
    {
        public static int Main(string[] args)
        {
            Test(0,1,1,1,2,2,2,3,3,3,4,4,4,5,5,6,6,6,7,7,7,7,8,8,8,8,9,9,9,9,9,10);
            Test(0,1,1,2,2,2,3,3,4,4,4,4,5,5,5,6,6,6,7,7,7,7,8,8,8,8,8,9,9,9,9,10);
    
            return 0;
        }
    
        public static void Test(params int[] _input)
        {
            var subsequences = _input
                .GroupBy(i => i)                   // get groups of identical elements
                .OrderByDescending(g => g.Count()) // FIXED (according to bullet 3. but enhanced)
                .ThenBy(g => g.Key);
    
            var attempt = Enumerable.Range(0, subsequences.Max(g => g.Count()))
                .SelectMany(i => subsequences.SelectMany(g => g.Skip(i).Take(1)))
                .ToArray().AsEnumerable();
    
            Console.WriteLine("shuffled\t"  + string.Join(", ", subsequences.SelectMany(g => g).TSA()));
            Console.WriteLine("spread\t" + string.Join(", ", attempt.TSA()));
    
            Console.WriteLine("ErrorIndex:\t{0} out of {1}", attempt.ErrorIndex(), attempt.Count());
            attempt = attempt.Concat(attempt);
            Console.WriteLine("ErrorIndex:\t{0} out of {1}", attempt.ErrorIndex(), attempt.Count());
            attempt = attempt.Concat(attempt);
            Console.WriteLine("ErrorIndex:\t{0} out of {1}", attempt.ErrorIndex(), attempt.Count());
        }
    
        public static int ErrorIndex(this IEnumerable<int> output)
        {
            var repl = output.ToArray();
            for (int i=1; i<repl.Length; i++) if (repl[i]==repl[i-1]) return i;
            for (int i=2; i<repl.Length; i++) if (repl[i]==repl[i-2]) return i;
    
            return -1;
        }
        private static string[] TSA<T>(this IEnumerable<T> e)
        {
            return e.Select(i => (null==i)? "" : i.ToString()).ToArray();
        }
        
    }
