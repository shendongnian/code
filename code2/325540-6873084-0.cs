        static string clear(string input)
        {
            string charsToBeCleared = ":|/-\“‘&*#@";
            string output = "";
            foreach (char c in input)
            {
                if (charsToBeCleared.IndexOf(c) < 0)
                {
                    output += c;
                }
            }
            return output;
        }
