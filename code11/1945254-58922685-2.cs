    public static List<KeyValuePair<string, string>> GetKVPs(string pattern, string search)
    {
        var results = new List<KeyValuePair<string, string>>();
        var keys = new List<string>();
        var delimeters = new List<string>();
        var currentKey = string.Empty;
        var currentDelimeter = string.Empty;
        var processingKey = false;
        // Populate our lists of Keys and Delimeters
        foreach (var chr in pattern)
        {
            switch (chr)
            {
                case '}':
                {
                    if (currentKey.Length > 0)
                    {
                        keys.Add(currentKey);
                        currentKey = string.Empty;
                    }
                    processingKey = false;
                    break;
                }
                case '{':
                {
                    if (currentDelimeter.Length > 0)
                    {
                        delimeters.Add(currentDelimeter);
                        currentDelimeter = string.Empty;
                    }
                    processingKey = true;
                    break;
                }
                default:
                {
                    if (processingKey)
                    {
                        currentKey += chr;
                    }
                    else
                    {
                        currentDelimeter += chr;
                    }
                    break;
                }
            }
        }
        if (currentDelimeter.Length > 0) delimeters.Add(currentDelimeter);
        var lastDelim = -1;
        // Find our Values based on the delimeter positions in the search string
        for (int i = 0; i < delimeters.Count; i++)
        {
            var delimIndex = search.IndexOf(delimeters[i], lastDelim + 1);
            if (delimIndex > -1)
            {
                var value = search.Substring(lastDelim + 1, delimIndex - lastDelim - 1);
                results.Add(new KeyValuePair<string, string>(keys[i], value));
                lastDelim = delimIndex + delimeters[i].Length - 1;
            }
        }
        // Add the item after the final delimeter if it exists:
        if (lastDelim > -1 && lastDelim < search.Length - 1)
        {
            results.Add(new KeyValuePair<string, string>(keys.Last(),
                search.Substring(lastDelim + 1)));
        }
        return results;
    }
