    public static string AbsolutePathToSubdomain(this Uri uri, string subdomain)
    {
        // Pre-process the new subdomain
        if (subdomain == null || subdomain.Equals("www", StringComparison.CurrentCultureIgnoreCase))
            subdomain = string.Empty;
        // Count number of TLDs (assume at least one)
        List<string> parts = uri.Host.Split('.').ToList();
        int tldCount = 1;
        if (parts.Count >= 2 && parts[parts.Count - 2].Length <= 3)
        {
            tldCount++;
        }
        // Drop all subdomains
        if (parts.Count - tldCount > 1)
            parts.RemoveRange(0, parts.Count - tldCount - 1);
        // Add new subdomain, if applicable
        if (subdomain != string.Empty)
            parts.Insert(0, subdomain);
        // Construct the new URI
        UriBuilder builder = new UriBuilder(uri);
        builder.Host = string.Join(".", parts.ToArray());
        builder.Path = "/";
        builder.Query = "";
        builder.Fragment = "";
        return builder.Uri.ToString();
    }
