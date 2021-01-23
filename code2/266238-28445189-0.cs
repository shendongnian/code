    public string ReverseWords(string str)
            {
                StringBuilder strrev = new StringBuilder();
                StringBuilder reversedword = new StringBuilder();
    
                foreach (var word in str.Split(' '))
                {
                    char[] singleWord = word.ToCharArray();
                    int j = singleWord.Length / 2;
                    for (int i = singleWord.Length - 1, c = 0; i >= j; c = c + 1, i = i - 1)
                    {
    
                        singleWord[c] = (char)(singleWord[c] ^ singleWord[i]);
                        singleWord[i] = (char)(singleWord[c] ^ singleWord[i]);
                        singleWord[c] = (char)(singleWord[c] ^ singleWord[i]);
    
                    }
                    strrev.Append(singleWord);
                    strrev.Append(" ");
                }
                return strrev.ToString();
            }
