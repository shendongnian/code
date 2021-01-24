    static string RepeatChars(string word, int times)
        {
            string newString = null;
            foreach(var character in word)
            {
                newString += new string(character, times);
            }
            return newString;
        }
