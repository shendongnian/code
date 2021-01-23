    public static string DeleteLines (string text, int lineCount) {
    while (text.Split('\n').Length > lineCount)
    text = text.Remove(0, text.Split('\n')[0].Length + 1);
    return text;
    }
