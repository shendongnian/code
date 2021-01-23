    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program {
        public static void Main() {
            IEnumerable<String> getResults = Enumerable.Repeat("A", 5);
            List<String> valuesToAppend = new List<String> { "B", "C" };
            foreach (var item in valuesToAppend) {
                string tmp = item;
                getResults = getResults.Select(s => s + " " + tmp);
            }
            foreach (var item in getResults) {
                Console.WriteLine(item);
            }
        }
    }
