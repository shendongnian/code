    public static string ReplaceArticleTextWithProductLinks(string input)
    {
        string pattern = @"\(\(MY TOPIC ID: ""(.*?)"" ""(.*?)""\)\)";
        return Regex.Replace(input, pattern,
            match => string.Format("<a href='/post/{0}'>{1}</a>",
                                   match.Groups[0].Value,
                                   match.Groups[1].Value));
    }
