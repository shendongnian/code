    public static class ConsoleInput
    {
        public static IEnumerable<int> ReadInts()
        {
            return SplitInput(Console.ReadLine()).Select(int.Parse);
        }
        private static IEnumerable<string> SplitInput(string input)
        {
            return Regex.Split(input, @"\s+")
                        .Where(x => !string.IsNullOrWhiteSpace(x));
        }
    }
