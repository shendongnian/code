    void Main()
    {
        List<string> input = new List<string>
        {
            "1", "5", "3", "6", "11", "9", "A1", "A0"
        };
        var output = input.NaturalSort();
        output.Dump();
    }
    
    public static class Extensions
    {
        public static IEnumerable<string> NaturalSort(
            this IEnumerable<string> collection)
        {
            return NaturalSort(collection, CultureInfo.CurrentCulture);
        }
    
        public static IEnumerable<string> NaturalSort(
            this IEnumerable<string> collection, CultureInfo cultureInfo)
        {
            return collection.OrderBy(s => s, new NaturalComparer(cultureInfo));
        }
    
        private class NaturalComparer : IComparer<string>
        {
            private readonly CultureInfo _CultureInfo;
            
            public NaturalComparer(CultureInfo cultureInfo)
            {
                _CultureInfo = cultureInfo;
            }
    
            public int Compare(string x, string y)
            {
                // simple cases
                if (x == y) // also handles null
                    return 0;
                if (x == null)
                    return -1;
                if (y == null)
                    return +1;
    
                int ix = 0;
                int iy = 0;
                while (ix < x.Length && iy < y.Length)
                {
                    if (Char.IsDigit(x[ix]) && Char.IsDigit(y[iy]))
                    {
                        // We found numbers, so grab both numbers
                        int ix1 = ix++;
                        int iy1 = iy++;
                        while (ix < x.Length && Char.IsDigit(x[ix]))
                            ix++;
                        while (iy < y.Length && Char.IsDigit(y[iy]))
                            iy++;
                        string numberFromX = x.Substring(ix1, ix - ix1);
                        string numberFromY = y.Substring(iy1, iy - iy1);
                        
                        // Pad them with 0's to have the same length
                        int maxLength = Math.Max(
                            numberFromX.Length,
                            numberFromY.Length);
                        numberFromX = numberFromX.PadLeft(maxLength, '0');
                        numberFromY = numberFromY.PadLeft(maxLength, '0');
                        
                        int comparison = _CultureInfo
                            .CompareInfo.Compare(numberFromX, numberFromY);
                        if (comparison != 0)
                            return comparison;
                    }
                    else
                    {
                        int comparison = _CultureInfo
                            .CompareInfo.Compare(x, ix, 1, y, iy, 1);
                        if (comparison != 0)
                            return comparison;
                        ix++;
                        iy++;
                    }
                }
                
                // we should not be here with no parts left, they're equal
                Debug.Assert(ix < x.Length || iy < y.Length);
                
                // we still got parts of x left, y comes first
                if (ix < x.Length)
                    return +1;
                    
                // we still got parts of y left, x comes first
                return -1;
            }
        }
    }
