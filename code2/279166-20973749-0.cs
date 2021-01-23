        private string sortLetters(string word)
        {
            var input = new System.Collections.Generic.SortedList<char, int>();
            foreach (var c in word.ToCharArray())
            {
                if (input.ContainsKey(c))
                    input[c]++;
                else
                    input.Add(c, 1);
            }
            var output = new StringBuilder();
            foreach (var kvp in input)
            {
                output.Append(kvp.Key, kvp.Value);
            }
            string s;
            
            return output.ToString();
        }
