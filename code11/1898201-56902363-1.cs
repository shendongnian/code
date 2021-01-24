    static int GetPort(string s)
    {
        int port = -1;
        if (string.IsNullOrEmpty(s))
            return port;
        ReadOnlySpan<char> span = s;
        int index = span.IndexOf(':');
        if (index == -1 || s.Length < index)
            return port;
        int.TryParse(span.Slice(index + 1), out port);
        return port;
    }
