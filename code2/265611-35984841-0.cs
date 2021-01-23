    public static class StringEx
    {
        public static bool Contains(this String str, string[] Arr, StringComparison comp)
        {
            if (Arr != null)
            {
                foreach (string s in Arr)
                {
                    if (str.IndexOf(s, comp)>=0)
                    { return true; }
                }
            }
            return false;
        }
        public static bool Contains(this String str,string[] Arr)
        {
            if (Arr != null)
            {
                foreach (string s in Arr)
                {
                    if (str.Contains(s))
                    { return true; }
                }
            }
            return false;
        }
    }
