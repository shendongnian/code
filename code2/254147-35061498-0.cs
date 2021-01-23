    public static class AlphanumericHelper
    {
        private struct Split
        {
            public string Prefix { get; private set; }
            public double Suffix { get; private set; }
    
            public Split(string prefix, double suffix) : this()
            {
                Prefix = prefix;
                Suffix = suffix;
            }
        }
    
        public static IEnumerable<string> Sort(string[] source, IFormatProvider provider = null)
        {
            var culture = provider ?? CultureInfo.CurrentCulture;
            var dict = new Dictionary<string, List<double>>(source.Length);
    
            foreach (string s in source)
            {
                var split = GetSplit(s, culture);
                List<double> list;
                if (dict.TryGetValue(split.Prefix, out list))
                    list.Add(split.Suffix);
                else
                    dict.Add(split.Prefix, new List<double> {split.Suffix});
            }
            foreach (var pair in dict.OrderBy(x => x.Key))
            {
                pair.Value.Sort();
                foreach (double d in pair.Value)
                {
                    yield return pair.Key + d;
                }
            }
        }
    
        private static Split GetSplit(string s, IFormatProvider cultureInfo)
        {
            int i;
            for (i = 0; i < s.Length && !char.IsDigit(s[i]); i++) ;
    
            return new Split(s.Remove(i), double.Parse(s.Substring(i), cultureInfo));
        }
    }
