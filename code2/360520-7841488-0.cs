    string ip = "127.0.0.1";
    string[] parts = ip.Split('.');
    if (parts.Length < 4)
    {
        // not a IPv4 string in X.X.X.X format
    }
    else
    {
        foreach(string part in parts)
        {
            byte checkPart = 0;
            if (!byte.TryParse(part, out checkPart))
            {
                // not a valid IPv4 string in X.X.X.X format
            }
        }
        // it is a valid IPv4 string in X.X.X.X format
    }
