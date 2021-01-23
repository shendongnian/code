    public class ManualParser : IParser
    {
        public IEnumerable<string> Parse(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return new List<string>();
            
            line = line.Trim();
            if (line.Contains(",") == false) return new[] { line.Trim('"') };
            if (line.Contains("\"") == false) return line.Split(',').Select(c => c.Trim());
            bool withinQuotes = false;
            var builder = new List<string>();
            var cur = new StringBuilder();
            foreach (char c in line.ToCharArray())
            {
                if (c == '"')
                {
                    withinQuotes = !withinQuotes;
                    continue;
                }
                
                if (c != ',' || withinQuotes)
                {
                    cur.Append(c);
                }
                if (c == ',' && !withinQuotes)
                {
                    builder.Add(cur.ToString().Trim());
                    cur = new StringBuilder();
                }
            }
            builder.Add(cur.ToString().Trim());
            return builder;
        }
    }
