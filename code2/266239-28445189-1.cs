    public  string ReverseWords(string str)
        {
            StringBuilder strrev = new StringBuilder();
            StringBuilder reversedword = new StringBuilder();
            foreach (var word in str.Split(' '))
            {
                char[] singlesentence = word.ToCharArray();
                int j = singlesentence.Length / 2;
                if (j > 0)
                {
                    for (int i = singlesentence.Length - 1, c = 0; i == j; c = c + 1, i = i - 1)
                    {
                        singlesentence[c] = (char)(singlesentence[c] ^ singlesentence[i]);
                        singlesentence[i] = (char)(singlesentence[c] ^ singlesentence[i]);
                        singlesentence[c] = (char)(singlesentence[c] ^ singlesentence[i]);
                    }
                }
                strrev.Append(singlesentence);
                strrev.Append(" ");
            }
            return strrev.ToString();
        }
