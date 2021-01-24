    var input = "\r\n\r\nMaster = \r\nSlave\r\nRed =\r\n Blue";
    var dict = new Dictionary<string, string>();
    var currentKey = "";
    foreach (var item in input.Split(new[] { '\r', '\n' }, 
        StringSplitOptions.RemoveEmptyEntries))
    {
        var parts = item.Split(new[] { '=' }, 
            StringSplitOptions.RemoveEmptyEntries);
        if (currentKey.Length == 0)
        {
            if (parts.Length > 1 && !string.IsNullOrWhiteSpace(parts[1]))
            {
                dict.Add(parts[0].Trim(), parts[1].Trim());
            }
            else
            {
                currentKey = parts[0].Trim();
            }
        }
        else
        {
            dict.Add(currentKey, parts.Length > 1 
                ? parts[1].Trim() 
                : parts[0].Trim());
            currentKey = "";
        }
    }
