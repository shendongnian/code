        private static bool IsAnagram(String s1, String s2)
        {
            if (String.IsNullOrEmpty(s1)) throw new ArgumentNullException("s1");
            if (String.IsNullOrEmpty(s2)) throw new ArgumentNullException("s2");
            Dictionary<char, int> m1 = new Dictionary<char, int>();
            Dictionary<char, int> m2 = new Dictionary<char, int>();
            // get the length of the longer string, this is used for the for loop below
            int length = s1.Length > s2.Length ? s1.Length : s2.Length;
            // iterate through both strings at the same time
            // verifies that the index is not out of bounds before checking if the current character is a letter
            // adds character to dictionary if it doesn't exist and increments count
            for (int i = 0; i < length; i++)
            {
                if (i < s1.Length && Char.IsLetter(s1[i]))
                {
                    if (!m1.ContainsKey(char.ToLower(s1[i])) m1.Add(char.ToLower(s1[i]), 0);
                    m1[char.ToLower(s1[i])]++;
                }
                if (i < s2.Length && Char.IsLetter(s2[i]))
                {
                    if (!m2.ContainsKey(char.ToLower(s2[i]) m2.Add(char.ToLower(s2[i]), 0);
                    m2[char.ToLower(s2[i])]++;
                }
            }
            // if the two dictionaries don't match in length bail out now
            if (m1.Count != m2.Count) return false;
            // uses first dictionary to verify key and value exist in second dictionary
            foreach (char current in m1.Keys)
            {
                if (!m2.ContainsKey(current)) return false;
                if (m1[current] != m2[current]) return false;
            }
            return true;
        }
