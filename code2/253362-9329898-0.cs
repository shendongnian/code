    private string padIP(string ip)
    {
        string output = string.Empty;
        string[] parts = ip.Split('.');
        for (int i = 0; i < parts.Length; i++)
        {
            output += parts[i].PadLeft(3, '0');
            if (i != parts.Length - 1)
                output += ".";
        }
        return output;
    }
