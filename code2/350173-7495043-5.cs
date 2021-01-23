    using System;
    using System.Collections;
    using System.Linq;
    
    class SomeType
    {
        public int SomeData = 5;
    
        public override string ToString()
        {
            return SomeData.ToString();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var blah = new Dictionary<string, SomeType>();
            blah.Add("test", new SomeType() { SomeData = 6 });
            // Build an enumeration of just matches:
            var entriesThatMatchValue = blah
                .Where(e => e.Value.SomeData == 6);
            foreach (KeyValuePair<string, SomeType> item in entriesThatMatchValue)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            }
            // or: ...
            // Build a sub-enumeration of just keys from matches:
            var keysThatMatchValue = entriesThatMatchValue.Select(e => e.Key);
            // Build a list of keys from matches in-line, using method chaining:
            List<string> matchingKeys = blah
                .Where(e => e.Value.SomeData == 6)
                .Select(e => e.Key)
                .ToList();
        }
    }
