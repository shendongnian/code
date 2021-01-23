      class StringEqualityComparer : IEqualityComparer<String>
    {
        public string val1;
        public bool Equals(String s1, String s2)
        {
            if (!s1.Equals(s2)) return false;
            val1 = s1;
            return true;
        }
        public int GetHashCode(String s)
        {
            return s.GetHashCode();
        }
    }
    public static class HashSetExtension
    {
        public static bool TryGetValue(this HashSet<string> hs, string value, out string valout)
        {
            if (hs.Contains(value))
            {
                valout=(hs.Comparer as StringEqualityComparer).val1;
                return true;
            }
            else
            {
                valout = null;
                return false;
            }
        }
    }
