        public static IEnumerable<string> SplitOnLength(this string s, int length)
        {
            return Regex.Split(s, @"(.{0," + length + @"}) ")
                .Where(x => x != string.Empty);
        }
