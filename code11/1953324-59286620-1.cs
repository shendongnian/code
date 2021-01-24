      public static string Info(string guess, string actual)
        {
            int correctNumbers = 0;
            string correctChars = "";
            List<char> charlists = actual.Select(x => (char)x).ToList();
            foreach (var char_ in guess)
            {
              
                if (charlists.Contains(char_))
                {
                    correctNumbers++;
                    correctChars += char_.ToString();
                    charlists.Remove(char_);                 
                }
            }
            return $"{correctNumbers}({correctChars})";
        }
