    public bool TestForAscending()
        {
            var regex = new Regex(@"(\d)(?=(\d{2}))");
            var target = "120847212340876";
            var matches = regex.Matches(target);
            List<string> groups = new List<string>();
            foreach( Match m in matches )
            {
                groups.Add(m.Groups[1].Value + m.Groups[2].Value);
            }
            return groups.Any(x => IsAscending(x));
        }
        public static bool IsAscending(string x)
        {
            if (x.Length == 1)
            {
                return true;
            }
            int last = int.Parse(x.Last().ToString());
            int prev = int.Parse(x[x.Length - 2].ToString());
            return last == prev + 1 && IsAscending(x.Substring(0, x.Length - 1));
        }
