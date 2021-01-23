    class Program
    {
        static void Main(string[] args)
        {
            var input = new string[] { "A", "A.B.D", "A", "A.B", "E", "F.E", "F", "B.C", "B.C.D", "B.E" };
            var output = FilterFunc(input);
            foreach (var str in output)
                Console.WriteLine(str);
            Console.ReadLine();
        }
        static string[] FilterFunc(string[] input)
        {
            if (input.Length <= 1)
                return input;
            else
            {
                var firstElem = input[0];
                var indexNr = firstElem.Length;
                var maxFilteredElems = 0;
                for (int i = firstElem.Length; i > 0; i--)
                {
                    var numberOfFilteredElems = input.Where(x => x.StartsWith(firstElem.Substring(0, i))).Count();
                    if (numberOfFilteredElems > maxFilteredElems)
                    {
                        maxFilteredElems = numberOfFilteredElems;
                        indexNr = i;
                    }
                }
                var prefix = firstElem.Substring(0, indexNr);
                var recursiveResult = FilterFunc(input.Where(x => !x.StartsWith(prefix)).ToArray());
                var result = recursiveResult.ToList();
                prefix = prefix.EndsWith(".") ? prefix.Substring(0, prefix.Length - 1) : prefix;
                result.Insert(0, prefix);
                return result.ToArray();
            }
        }
    }
