    public static List<string> CombineWords(params string[][] arraysOfWords)
    {
        var strings = new List<string>();
        if (arraysOfWords.Length == 0)
        {
            return strings;
        }
        Action<string, int> combineWordsInternal = null;
        combineWordsInternal = (baseString, index) =>
        {
            foreach (var str in arraysOfWords[index])
            {
                string str2 = baseString + " " + str;
                if (index + 1 < arraysOfWords.Length)
                {
                    combineWordsInternal(str2, index + 1);
                }
                else
                {
                    strings.Add(str2);
                }
            }
        };
        combineWordsInternal(string.Empty, 0);
        return strings;
    }
