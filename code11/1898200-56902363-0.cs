    static readonly char[] s_splitter = new char[1] { ':' };
    static int GetPort(string s)
    {
        int port = -1;
        if (string.IsNullOrEmpty(s))
            return port;
        string[] parts = s.Split(s_splitter);
        if (parts.Length == 2)
            int.TryParse(parts[1], out port);
        return port;
    }
