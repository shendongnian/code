     public static bool CanBeMadeFrom(string word, string letters)
        {
            foreach (var c in word)
            {
                if (!letters.Contains(c)) return false;
                letters = letters.Remove(letters.IndexOf(c, 0), 1);
            }
            return true;
        }
