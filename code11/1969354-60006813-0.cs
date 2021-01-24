    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            Example();
        }
        public static void Example()
        {
            var sorted = new SortedDictionary<string, int>
            {
                {"1", 1 },
                {"3", 3 },
                {"0", 0 },
                {"2", 2 },
                {"4", 4 }
            };
            var fromValues1 = sorted.Values.GetEnumerator();
            // fromValue1 type is struct System.Collections.Generic.SortedDictionary<string,int>.ValueCollection.Enumerator
            fromValues1.MoveNext();
            while (printNextValue(fromValues1)) // Prints 0 once for each value in the dictionary.
                ;
            Console.WriteLine("-----------------");
            IEnumerator<int> fromValues2 = sorted.Values.GetEnumerator();
            // fromValues2 type is boxed struct System.Collections.Generic.SortedDictionary<string,int>.ValueCollection.Enumerator
            fromValues2.MoveNext();
            while (printNextValue(fromValues2)) // Prints each value in the dictionary.
                ;
        }
        static bool printNextValue(IEnumerator<int> enumerator)
        {
            Console.WriteLine(enumerator.Current);
            return enumerator.MoveNext();
        }
    }
