        /// <summary>
        /// Compare two strings and return the index of the first difference.  Return -1 if the strings are equal.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        int DiffersAtIndex(string s1, string s2)
        {
            int index = 0;
            int min = Math.Min(s1.Length, s2.Length);
            while (index < min && s1[index] == s2[index]) 
                index++;
            return (index == min && s1.Length == s2.Length) ? -1 : index;
        }
