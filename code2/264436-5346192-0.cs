    public static object[] ExtractFormatParameters(this string sourceString, string formatString)
    {
        Regex placeHolderRegex = new Regex(@"\{(\d+)\}");
        Regex formatRegex = new Regex(placeHolderRegex.Replace(formatString, m => "(<" + m.Groups[1].Value + ">.*?)");
        Match match = formatRegex.Match(sourceString);
        if (match.Success)
        {
            var output = new object[match.Groups.Count-1];
            for (int i = 0; i < output.Length; i++)
                output[i] = match.Groups[i+1].Value;
            return output;
        }
        return new object[];
    } 
