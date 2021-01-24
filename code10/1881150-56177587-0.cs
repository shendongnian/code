    /// <summary>Adds a function to dereference just the base name portion of an Assembly from the FullName.</summary>
    /// <returns>The extracted base name if able, otherwise just the FullName.</returns>
    public static string ExtractName(this Assembly root)
    {
        string pattern = @"^(?<assy>(?:[a-zA-Z\d]+[.]?)+)(?>,).*$", work = root.FullName;
        MatchCollection matches = Regex.Matches(work, pattern, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
        if (matches.Count > 0) return matches[0].Groups["assy"].Value;
        if (work.IndexOf(",") > 3) return work.Substring(0, work.IndexOf(','));
        return root.FullName;
    }
