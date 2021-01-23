    public static bool IsValidURI(string uri)
    {
        if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            return false;
        return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
    }
