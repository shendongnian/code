    public static void CombineWordsInternal(string[][] arraysOfWords, List<string> strings, string baseString, int index)
    {
        for (int i = 0; i < arraysOfWords[index].Length; i++)
        {
            string str = baseString + " " + arraysOfWords[index][i];
            if (index + 1 < arraysOfWords.Length)
            {
                CombineWordsInternal(arraysOfWords, strings, str, index + 1);
            }
            else
            {
                strings.Add(str);
            }
        }
    }
    public static List<string> CombineWords(params string[][] arraysOfWords)
    {
        var strings = new List<string>();
        if (arraysOfWords.Length == 0)
        {
            return strings;
        }
        CombineWordsInternal(arraysOfWords, strings, string.Empty, 0);
        return strings;
    }
