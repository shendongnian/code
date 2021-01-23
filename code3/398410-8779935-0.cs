    public IEnumerable<KeyValuePair<string, string>> Parse(StreamReader reader)
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            var tokens = Regex.Split(line, @"\(\d+\)\:");
            if (tokens.Length > 1)
            {
                var file = Path.GetFileName(tokens[0]);
                var match = Regex.Match(tokens[1], @"HeaderText=\""(\w+)\""");
                if (match.Success)
                {
                    yield return new KeyValuePair<string, string>(
                        file, match.Groups[1].Value
                    );
                }
            }
        }
    }
