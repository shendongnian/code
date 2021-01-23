    private static string[] SmartSplit(string line, char separator = ',')
    {
        var inQuotes = false;
        var token = "";
        var lines = new List<string>();
        for (var i = 0; i < line.Length; i++) {
            var ch = line[i];
            if (inQuotes) // process string in quotes, 
            {
                if (ch == '"') {
                    if (i<line.Length-1 && line[i + 1] == '"') {
                        i++;
                        token += '"';
                    }
                    else inQuotes = false;
                } else token += ch;
            } else {
                if (ch == '"') inQuotes = true;
                else if (ch == separator) {
                    lines.Add(token);
                    token = "";
                    } else token += ch;
                }
        }
        lines.Add(token);
        return lines.ToArray();
    }
