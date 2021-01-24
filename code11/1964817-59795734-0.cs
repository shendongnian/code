    public static class ExtensionMethods
    {
        public class MatrixItem<T>
        {
            public int X { get; set; }
            public int Y { get; set; }
            public T Value { get; set; }
        }
        static public IEnumerable<MatrixItem<T>> Flatten<T>(this T[,] source)
        {
            for (int i = source.GetLowerBound(0); i <= source.GetUpperBound(0); i++)
            {
                for (int j = source.GetLowerBound(1); j <= source.GetUpperBound(1); j++)
                {
                    yield return new MatrixItem<T> { X = j, Y = i, Value = source[i, j] };
                }
            }
        }
    }
