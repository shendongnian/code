        class Program
    {
        static void Main(string[] args)
        {
            string firstWord = String.Empty;
            string secondWord = String.Empty;
            Console.WriteLine("Check if two strings are anagrams");
            Console.WriteLine("Enter First String");
            firstWord = Console.ReadLine();
            Console.WriteLine("Enter Second String");
            secondWord = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Ara Anagram: " + AreAnagrams(firstWord.ToLower(), secondWord.ToLower()).ToString());
            Console.ReadLine();
        }
        private static bool AreAnagrams(string firstWord, string secondWord)
        {
            if (firstWord.Length == 0 || firstWord.Length != secondWord.Length)
                return false;
            string letters = new String(firstWord.Distinct().ToArray());
            foreach (char letter in letters)
            {
                char lowerLetter = Char.ToLower(letter);
                if (firstWord.Count(c => c == lowerLetter) != secondWord.Count(c => c == lowerLetter)) return false;
            }
            return true;
        }
    }
