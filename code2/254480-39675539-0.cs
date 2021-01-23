    class Program
    {
        static void Main(string[] args)
        {
            var longestWord = LongestWord("Hello Stack Overflow Welcome to Challenge World");
            PrintTheLongestWord(longestWord);
        }
        public static KeyValuePair<string, int> LongestWord(String statement)
        {
            Dictionary<string, int> wordsLengths = InitializeDictionary(statement.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            return GetMax(wordsLengths);
        }
        private static Dictionary<string, int> InitializeDictionary(string[] wordsList)
        {
            Dictionary<string, int> wordsLengths = new Dictionary<string, int>();
            foreach (var word in wordsList)
            {
                wordsLengths[word] = word.Length;
            }
            return wordsLengths;
        }
        private static KeyValuePair<string, int> GetMax(Dictionary<string, int> dictionary)
        {
            KeyValuePair<string, int> max = new KeyValuePair<string, int>(" ", Int32.MinValue);
            foreach (var item in dictionary)
            {
                if (item.Value.CompareTo(max.Value) > 0)
                    max = item;
            }
            return max;
        }        
        public static void PrintTheLongestWord(KeyValuePair<string, int> longestWord)
        {
            Console.WriteLine($"the Longest word is {longestWord.Key} with lenght {longestWord.Value}");
        }    
    }
