        private static string [] SplitWords(string s, int startWord)
        {
            string[] words = s.Split(' ');
            List<string> output = new List<string>();
            output.AddRange(words.Skip(startWord).ToArray());
            output.AddRange(words.Take(startWord).ToArray());
            return output.ToArray();
        }
