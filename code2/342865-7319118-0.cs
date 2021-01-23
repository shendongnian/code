    public static class LINQTo2DArray
    {
        public static IEnumerable<T> Row<T>(this T[,] Array, int Row)
        {
            for (int i = 0; i < Array.GetLength(1); i++)
            {
                yield return Array[Row, i];
            }
        }
        public static IEnumerable<T> Column<T>(this T[,] Array, int Column)
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                yield return Array[i, Column];
            }
        }
    }
