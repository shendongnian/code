    private static string UrlModuleName(this string url)
    {
        return Regex.Replace(url.Split('/')[1], "([a-z])([A-Z])",
                             "$1 $2").ToTitleCaseInvariant();
    }
    private static string ToTitleCaseInvariant(this string input)
    {
        return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(input);
    }
