    private static string ToTitleCase(string input)
    {
        return input == null
            ? null
            : HttpUtility.HtmlEncode(CultureInfo.InvariantCulture.TextInfo
                .ToTitleCase(HttpUtility.HtmlDecode(input.ToLowerInvariant())));
    }
