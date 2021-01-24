            Regex itemRegex = new Regex(@"[^A-Za-z0-9<>[\]:\.,_\s-]", RegexOptions.Compiled); // {1} is implied
            foreach (Match itemMatch in itemRegex.Matches(s))
            {
                char unicodeChar = itemMatch.ToString().ToCharArray()[0]; // 1 char = 16 bits
                int unicodeNumber = (int)unicodeChar;
                string unicodeHex = unicodeNumber.ToString("X4");
                s = s.Replace(itemMatch.ToString(), "<U+" + unicodeHex + ">");
            }
            return s;
