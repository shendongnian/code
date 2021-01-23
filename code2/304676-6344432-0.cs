    public static string StripWordsWithLessThanXLetters(string input, int x)
    {
        var inputElements = input.Split(' ');
        var resultBuilder = new StringBuilder();
        foreach (var element in inputElements)
        {
            if (element.Length >= x)
            {
                resultBuilder.Append(element + " ");
            }
        }
        return resultBuilder.ToString().Trim();
    }
