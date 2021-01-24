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
If the key is a string only you do not need the class `Subreddit` with only one string property. You could simplify it to this and use the default implementation to sort strings.
using System;
using System.Collections.Generic;
namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedDictionary = new SortedDictionary<string, Payload>();
            sortedDictionary.Add("B", new Payload());
            sortedDictionary.Add("A", new Payload());
            sortedDictionary.Add("C", new Payload());
            foreach (var keyValuePair in sortedDictionary)
            {
                Console.WriteLine($"{keyValuePair.Key}");
            }
            Console.WriteLine("Press any key to exit program.");
            Console.ReadKey();
        }
    }
    public class Payload
    {
        public string Data1 { get; set; }
        public int Data2 { get; set; }
    }
}
/*
  The Output will be:
  A
  B
  C
*/
