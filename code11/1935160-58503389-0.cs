    public static class StringExtensions
    {
        public static bool Contains(this string self, params string[] values)
        {
            for(int ix = 0; ix < values.Length; ++ix)
                if(!self.Contains(values[ix]))
                    return false;
            return true;
        }
    }
