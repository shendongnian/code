    private Regex LikeExpressionToRegexPattern(String likePattern)
    {
        var replacementToken = "~~~";
        String result = likePattern.Replace("_", replacementToken)
            .Replace("%", ".*");
        result = Regex.Replace(result, @"\[.*" + replacementToken + @".*\]", "_");
        result = result.Replace(replacementToken, ".");
        return new Regex("^" + result + "$", RegexOptions.IgnoreCase);
    }
