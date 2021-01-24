using System;
using System.Collections.Generic;
namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedDictionary = new SortedDictionary<Subreddit, Payload>(new KeyComparer());
            sortedDictionary.Add(new Subreddit {Name = "B"}, new Payload());
            sortedDictionary.Add(new Subreddit {Name = "A"}, new Payload());
            sortedDictionary.Add(new Subreddit {Name = "C"}, new Payload());
            foreach (var keyValuePair in sortedDictionary)
            {
                Console.WriteLine($"{keyValuePair.Key.Name}");
            }
            Console.WriteLine("Press any key to exit program.");
            Console.ReadKey();
        }
    }
    public class Subreddit
    {
        public string Name { get; set; }
    }
    public class Payload
    {
        public string Data1 { get; set; }
        public int Data2 { get; set; }
    }
    public class KeyComparer : IComparer<Subreddit>
    {
        public int Compare(Subreddit x, Subreddit y)
        {
            if (x?.Name == null)
                throw new ArgumentException("[Subreddit]:CompareTo argument is not a Subreddit", nameof(x));
            if (y?.Name == null)
                throw new ArgumentException("[Subreddit]:CompareTo argument is not a Subreddit", nameof(y));
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }
}
/*
  The Output will be:
  A
  B
  C
*/
