    /// <summary>
    /// Gets the indexed entry.
    /// </summary>
    /// <param name="entry">The log entry.</param>
    /// <returns>The log entry prefixed with the index.</returns>
    private string GetIndexedEntry(string entry)
    {
        string keyword = GetKeyword(entry);
        switch (keyword)
        {
            case "books":
                entry = "1 : " + entry;
                break;
            case "resources":
                entry = "2 : " + entry;
                break;
        }
        return entry;
    }
    /// <summary>
    /// Gets the keyword.
    /// </summary>
    /// <param name="entry">The log entry.</param>
    /// <returns>The keyword for the specified log entry.</returns>
    private string GetKeyword(string entry)
    {
        int index = entry.IndexOf("\"GET");
        entry = entry.Substring(index + ("\"GET").Length);
        index = entry.IndexOf('"');
        entry = entry.Substring(0, index).Trim();
        return entry.Split('/')[1];
    }
