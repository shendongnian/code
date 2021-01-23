       public static bool CanBeMadeFrom(string word, string letters)
        {
            foreach (var i in word.Select(c => letters.IndexOf(c, 0)))
            {
                if (i == -1) return false;
                letters = letters.Remove(i, 1);
            }
            return true;
        }
