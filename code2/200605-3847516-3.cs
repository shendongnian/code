    static void Main(string[] args)
        {
            var items = new[] { -1, 0, 1, 21, -2, 4, 7, 9, 12, 22, 17, 8, 2, 20, 23 };
            IEnumerable<IEnumerable<int>> sequences = FindSequences(items, 3);
            foreach (var sequence in sequences)
            {   //print results to consol
                Console.Out.WriteLine(sequence.Select(num => num.ToString()).Aggregate((a, b) => a + "," + b));
            }
            Console.ReadLine();
        }
        private static IEnumerable<IEnumerable<int>> FindSequences(IEnumerable<int> items, int minSequenceLength)
        {
            //Convert item list to dictionary
            var itemDict = new Dictionary<int, int>();
            foreach (int val in items)
            {
                itemDict[val] = val;
            }
            var allSequences = new List<List<int>>();
            //for each val in items, find longest sequence including that value
            foreach (var item in items)
            {
                var sequence = FindLongestSequenceIncludingValue(itemDict, item);
                allSequences.Add(sequence);
                //remove items from dict to prevent duplicate sequences
                sequence.ForEach(i => itemDict.Remove(i));
            }
            //return only sequences longer than 3
            return allSequences.Where(sequence => sequence.Count >= minSequenceLength).ToList();
        }
        //Find sequence around start param value
        private static List<int> FindLongestSequenceIncludingValue(Dictionary<int, int> itemDict, int value)
        {
            var result = new List<int>();
            //check if num exists in dictionary
            if (!itemDict.ContainsKey(value))
                return result;
            //initialize sequence list
            result.Add(value);
            //find values greater than starting value
            //and add to end of sequence
            var indexUp = value + 1;
            while (itemDict.ContainsKey(indexUp))
            {
                result.Add(itemDict[indexUp]);
                indexUp++;
            }
            //find values lower than starting value 
            //and add to start of sequence
            var indexDown = value - 1;
            while (itemDict.ContainsKey(indexDown))
            {
                result.Insert(0, itemDict[indexDown]);
                indexDown--;
            }
            return result;
        }
