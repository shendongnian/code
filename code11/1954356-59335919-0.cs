        public List<string> GetValueByRegex(string input)
        {
            string pattern = @"<Person>([\s\S]*?)</Person>";
      
            var matches = Regex.Matches(input, pattern);
            if (matches.All(m => !m.Success))
                return null;
            var result = new List<string>();
            foreach (Match match in matches)
            {
                result.Add(match.Groups[1].Value);
            }
            return result;
        }
