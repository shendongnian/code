    using System;
    using System.Collections.Generic;
    using System.Linq;
    class MainClass {
        public static void Main (string[] args) {
            var list = new List<string> { "Lambda", "Aardvark", "Lexicon" };
            // This is now just an IEnumerable that will
            // call the Where and OrderBy when it is enumerated.
            var filteredEnum = Filter(list);
            list.RemoveAt(1);
            list.Add("Leisure");
            foreach(var word in filteredEnum)
                Console.WriteLine(word);
        }
        public static IEnumerable<string> Filter(List<string> strings)
        {
            return strings.Where(i => i.StartsWith("L") || i.StartsWith("l")).OrderBy(x => x);
        }
    }
