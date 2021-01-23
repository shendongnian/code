        public static string[] ParseLine(string line)
        {
            var insideQuotes = false;
            var start = -1;
            var parts = new List<string>();
            for (var i = 0; i < line.Length; i++)
            {
                if (Char.IsWhiteSpace(line[i]))
                {
                    if (!insideQuotes)
                    {
                        if (start != -1)
                        {
                            parts.Add(line.Substring(start, i - start));
                            start = -1;
                        }
                    }
                }
                else if (line[i] == '"')
                {
                    if (start != -1)
                    {
                        parts.Add(line.Substring(start, i - start));
                        start = -1;
                    }
                    insideQuotes = !insideQuotes;
                }
                else
                {
                    if (start == -1)
                        start = i;
                }
            }
            if (start != -1)
                parts.Add(line.Substring(start));
            return parts.ToArray();
        }
