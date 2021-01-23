    static IEnumerable<Tuple<DateTime, string>> GetLogEntries(string path)
    {
        var regex = new Regex(@"^(\d{2}\:\d{2}\:\d{2}\.\d{3}\s)(.*)", RegexOptions.Compiled);
    
        var logLineBuilder = new StringBuilder();
        Match currentMatch = null;
    
        foreach(var line in File.ReadLines(path))
        {
            var match = regex.Match(line);
    
            if (match.Success && logLineBuilder.Length != 0)
            {
                yield return Tuple.Create(DateTime.Parse(currentMatch.Groups[1].Value), logLineBuilder.ToString());
                logLineBuilder.Clear();
            }
    
            if (match.Success)
                currentMatch = match;
    
            logLineBuilder.AppendLine(match.Success ? match.Groups[2].Value : line);
        }
    
        yield return Tuple.Create(DateTime.Parse(currentMatch.Groups[1].Value), logLineBuilder.ToString());
    }
