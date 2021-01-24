    static string GetTagsAroud(string input, string splitText)
    {
        var matches = Regex.Split(input, splitText);
        StringBuilder output = new StringBuilder();
        foreach (string match in matches)
        {
            output.Append("<b>");
            output.Append(match.Trim());
            output.Append("</b>");
        }
        return output.ToString();
    }
