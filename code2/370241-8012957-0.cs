    public IEnumerable<string> GetLogEntries(string header)
    {
        if (log != null && log.ContainsKey(header))
        {
            return log[header];
        }
        return null;
    }
