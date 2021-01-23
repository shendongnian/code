        public static void Main(string[] args)
        {
            var dict = new Dictionary<string, string> { { "1", "one" }, { "2", "two" }, { "3", "three" }, { "4", "four" }, { "5", "five" }, { "6", "six" } };
            var lists = ChunkDict(dict, 2);
            var i = 0;
            foreach (var list in lists)
            {
                Console.WriteLine("List with index {0} has count {1}", i, list.Count);
                foreach (var dictionaryEntry in list)
                {
                    Console.WriteLine(dictionaryEntry.Key + ": " + dictionaryEntry.Value);
                }
                i++;
            }
            Console.ReadLine();
        }
        public static List<List<KeyValuePair<string, string>>> ChunkDict(Dictionary<string, string> theList, int chunkSize)
        {
            var result = theList.Select((x, i) =>
                new { data = x, indexgroup = i / chunkSize })
                .GroupBy(x => x.indexgroup, x => x.data)
                .Select(y => y.Select(x => x).ToList()).ToList();
            return result;
        }
