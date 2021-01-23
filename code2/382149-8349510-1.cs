    public class AnagramSolver
    {
        public AnagramSolver(IEnumerable<string> dictionary)
        {
            // Create our lookup by keying on the sorted letters:
            this.dictionary = dictionary.ToLookup<string, string>(SortLetters);
        }
        private ILookup<string, string> dictionary;
        public IEnumerable<string> SolveAnagram(string anagram, int minimumLength)
        {
            return CreateCombinations(anagram, minimumLength)
                // Sort the letters:
                .Select<string, string>(SortLetters)
                // Make sure we don't have duplicates:
                .Distinct()
                // Find all words that can be made from these letters:
                .SelectMany(combo => dictionary[combo])
                ;
        }
        private static string SortLetters(string letters)
        {
            char[] chars = letters.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
        /// <summary> Creates all possible combinations of all lengths from the anagram. </summary>
        private static IEnumerable<string> CreateCombinations(string anagram, int minimumLength)
        {
            var letters = anagram.ToCharArray();
            
            // Create combinations of every length:
            for (int length = letters.Length; length >= minimumLength; length--)
            {
                yield return new string(letters, 0, length);
                // Swap characters to form every combination:
                for (int a = 0; a < length; a++)
                {
                    for (int b = length; b < letters.Length; b++)
                    {
                        // Swap a <> b if necessary:
                        char temp = letters[a];
                        if (temp != letters[b]) // reduces duplication
                        {
                            letters[a] = letters[b];
                            letters[b] = temp;
                            yield return new string(letters, 0, length);
                        }
                    }
                }
            }
        }
    }
