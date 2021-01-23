    private static string RemoveEmptyLines(string text)
    {
        var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        var sb = new StringBuilder(text.Length);
        foreach (var line in lines)
        {
            sb.AppendLine(line);
        }
        return sb.ToString();
    }
