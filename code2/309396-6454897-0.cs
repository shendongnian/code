        public static string IncrementXLColumn(string Address)
        {
            var parts = System.Text.RegularExpressions.Regex.Matches(Address,  @"([A-Z]+)|(\d+)");
            if (parts.Count != 2) return null;
            return incCol(parts[0].Value) + parts[1].Value;
        }
        private static string incCol(string col)
        {
            if (col == "") return "A";
            string fPart = col.Substring(0, col.Length - 1);
            char lChar = col[col.Length - 1];
            if (lChar == 'Z') return incCol(fPart) + "A";
            return fPart + ++lChar;
        }
