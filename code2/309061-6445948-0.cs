    using System;
    using System.Collections.Generic;
    class Program {
        static void Main(string[] args) {
            List<string> firstNames = new List<string>();
            firstNames.Add("John");
            firstNames.Add("Mary");
            firstNames.Add("Jane");
            Console.WriteLine(NamesString(firstNames));
        }
        static string NamesString(List<string> firstNames) {
            switch (firstNames.Count) {
            case 0:
                return string.Empty;
            case 1:
                return firstNames[0];
            case 2:
                return string.Join(" and ", firstNames.ToArray());
            default:
                return string.Format("{0} and {1}",
                    string.Join(", ", firstNames.ToArray(), 0, firstNames.Count - 1),
                    firstNames[firstNames.Count - 1]);
            }
        }
    }
