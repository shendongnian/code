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
            Hashtable blah = new Hashtable();
            blah.Add("test", new SomeType() { SomeData = 6 });
            // Build an enumeration of just matches:
    
            var entriesThatMatchValue = blah.OfType<DictionaryEntry>()
                .Where(e => ((SomeType)e.Value).SomeData == 6);
    
            foreach (DictionaryEntry item in entriesThatMatchValue)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            }
            // or: ...
            // Build a sub-enumeration of just keys from matches:
            var keysThatMatchValue = entriesThatMatchValue.Select(e => e.Key);
            // Build a list of keys from matches in-line, using method chaining:
            List<string> matchingKeys = blah.OfType<DictionaryEntry>()
                .Where(e => ((SomeType)e.Value).SomeData == 6)
                .Select(e => (string)e.Key)
                .ToList();
        }
    }
