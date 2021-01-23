    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    
    class Example
    {
        static void Main()
        {
            var seqOne = new List<int> { 1, 2, 3, 4, 5, 6 };
            var seqTwo = new List<int> { 6, 5, 4, 3, 2, 1 };
    
            var seqOneCode = seqOne.AsReadOnly().GetSequenceHashCode();
            var seqTwoCode = seqTwo.AsReadOnly().GetSequenceHashCode();
    
            Console.WriteLine(seqOneCode == seqTwoCode);
        }
    }
    
    static class Extensions
    {
        public static int GetSequenceHashCode<T>(this ReadOnlyCollection<T> sequence)
        {
            return sequence
                .Select(item => item.GetHashCode())
                .Aggregate((total, nextCode) => total ^ nextCode);
        }
    }
