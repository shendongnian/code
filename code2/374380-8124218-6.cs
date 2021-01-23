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
            var trimChars = new[] { ' ', '"' };
            int left = 0;
            int right = 0;
            for (right = 0; right < line.Length; right++)
            {
                char c = line[right];
                if (c == '"')
                {
                    withinQuotes = !withinQuotes;
                    continue;
                }
                
                if (c == ',' && !withinQuotes)
                {
                    builder.Add(line.Substring(left, right - left).Trim(trimChars));
                    right++; // Jump the comma
                    left = right;
                }
            }
            builder.Add(line.Substring(left, right - left).Trim(trimChars));
            return builder;
        }
    }
