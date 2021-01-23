    static class RowColExtension
    {
        public static void Each(this int[][] rowCols, Action<int> a)
        {
            foreach (var r in rowCols)
            {
                foreach (var c in r)
                {
                    a(c);
                }
            }
        }
    }
