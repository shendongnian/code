        public static IEnumerable<string> GetAlphabetizedUniqueWords(string sentence)
        {
            return (sentence ?? string.Empty)
                .Split()
                .Select(x => x.ToLowerInvariant())
                .Distinct()
                .OrderBy(x => x);
        }
        static void Main( )
        {
            Console.Write("Enter your sentence. No punctuation.   : ");
            foreach (var word in GetAlphabetizedUniqueWords(Console.ReadLine()))
                Console.WriteLine(word);
        }
