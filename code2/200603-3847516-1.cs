    static void Main(string[] args)
        {
            var items = new[] { 21, 4, 7, 9, 12, 22, 17, 8, 2, 20, 23 };
            IEnumerable<List<int>> sequences = FindSequences(items);
            foreach (var sequence in sequences)
            {   //print results to console
                Console.Out.WriteLine(sequence.Select(num => num.ToString()).Aggregate((a, b) => a + "," + b));
            }
            Console.ReadLine();
        }
        private static IEnumerable<List<int>> FindSequences(IEnumerable<int> items)
        {
            //dictionary holds items not yet part of a sequence
            var itemDict = new Dictionary<int, int>();
            foreach (int val in items)
            {
                itemDict[val] = val;
            }
            //for each val in items, find sequence including that value
            //if size >=3, add it to result list
            return items.Select(start => FindLongestSequenceIncludingValue(itemDict, start)).Where(sequence => sequence.Count >= 3).ToList();
        }
        //Find sequence around start param value
        private static List<int> FindLongestSequenceIncludingValue(Dictionary<int, int> itemDict, int value)
        {
            var result = new List<int>();
            //num already part of a previous sequence or not in initial list
            if (!itemDict.ContainsKey(value))
                return result;
            //initialize sequence list
            result.Add(value);
            itemDict.Remove(value);
            //find values greater than starting value
            //and add to end of sequence
            var indexUp = value + 1;
            while (itemDict.ContainsKey(indexUp))
            {
                result.Add(itemDict[indexUp]);
                //remove from dict to prevent duplicate lists
                itemDict.Remove(indexUp);
                indexUp++;
            }
            //find values lower than starting value 
            //and add to start of sequence
            var indexDown = value - 1;
            while (itemDict.ContainsKey(indexDown))
            {
                result.Insert(0, itemDict[indexDown]);
                //remove from dict to prevent duplicate lists
                itemDict.Remove(indexDown);
                indexDown--;
            }
            return result;
        }
