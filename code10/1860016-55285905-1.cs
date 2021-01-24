    private readonly char newLineMarker = Environment.NewLine.Last();
    private readonly char[] newLine = Environment.NewLine.ToCharArray();
    private readonly char eof = '\uffff';
    
    private IEnumerable<string> EnumerateLines(string path)
    {
        using (var sr = new StreamReader(path))
        {
            char c;
            var sb = new StringBuilder();
            while ((c = (char)sr.Read()) != eof)
            {
                sb.Append(c);
                if (c == newLineMarker &&
                    sb.ToString().EndsWith(Environment.NewLine))
                {
                    var line = sb.ToString().Trim(newLine);
                    sb.Clear();
                    sb.Append(Environment.NewLine);
    
                    yield return line;
                }
            }
    
            if (sb.Length > 0)
                yield return sb.ToString().Trim(newLine);
        }
    }
