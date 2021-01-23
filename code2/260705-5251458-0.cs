    public static string[] ParseLine(string line)
            {
                var insideQuotes = false;
    
                var parts = new List<string>();
    
                var j = 0;
    
                for (var i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case '"':
                             insideQuotes = !insideQuotes;
                             break;
                        case ' ':
                             if (!insideQuotes)
                             {
                                 parts.Add(line.Substring(j, i - j));
                                 j = i + 1;
                             }
                             break;
                        default:
                             continue;
                    }
                }
    
                return parts.ToArray();
            }
