        static int GetNumber(string text)
        {
            string pat = @"\d+";
            int output;
            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(text);
            if (int.TryParse(m.Value, out output))
                return output;
            else
                return int.MinValue; // something unlikely
        }
        static char GetChar(string text)
        {
            string pat = @"[^\d]";
            int output;
            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(text);
            return m.Value.Length == 1 ? m.Value[0] : '\0';
        }
