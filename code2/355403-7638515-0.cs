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
        static string GetChar(string text)
        {
            string pat = @"[^\d]";
            int output;
            // Instantiate the regular expression object.
            Regex r = new Regex(pat, RegexOptions.IgnoreCase);
            Match m = r.Match(text);
            return m.Value;
        }
