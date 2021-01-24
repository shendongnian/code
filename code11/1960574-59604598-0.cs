    static string longestWord(String s1)
        {
            char emp = ' ';
            int count = 0;
            int maxLength = 0;
            string maxWord = string.Empty;
            List<char> newWord = new List<char>();
            char[] ee = s1.ToCharArray();
            for (int i = 0; i < ee.Length; i++)
            {
                if (ee[i] == emp || ee[i] == '.')
                {                    
                    if (maxLength < count)
                    {
                        maxLength = count;
                        maxWord = new string(newWord.ToArray());
                    }
                    count = 0;
                    newWord = new List<char>();
                }
                else
                {
                    newWord.Add(ee[i]);
                    count++;
                }
            }
            return maxWord;
        }
