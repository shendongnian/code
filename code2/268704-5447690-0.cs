    public class DiacriticStringComparer : IComparer<string>
    {
        private static readonly HashSet<char> _Specials = new HashSet<char> { 'é', 'ń', 'ó', 'ú' };
        public int Compare(string x, string y)
        {
            // handle special cases first: x == null and/or y == null,  x.Equals(y)
            ...
            var lengthToCompare = Math.Min(x.Length, y.Length);
            for (int i = 0; i < lengthToCompare; ++i)
            {
                var cx = x[i];
                var cy = y[i];
                if (cx == cy) continue;
                if (_Specials.Contains(cx) || _Specials.Contains(cy))
                {
                    // handle special diacritics comparison
                    ...
                }
                else
                {
                    // cx must be unequal to cy -> can only be larger or smaller
                    return cx < cy ? -1 : 1;
                }
            }
            // once we are here the strings are equal up to lengthToCompare characters
            // we have already dealt with the strings being equal so now one must be shorter than the other
            return x.Length < y.Length ? -1 : 1;
        }
    }
