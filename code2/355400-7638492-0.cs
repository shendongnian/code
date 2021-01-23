        private char GetChar(string t)
        {
            return t.Substring(t.Length - 1, 1)[0];
        }
        private int GetNumber(string t)
        {
            return Int32.Parse(t.Substring(0, t.Length - 1));
        }
