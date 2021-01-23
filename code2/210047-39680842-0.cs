    public static class ExtensionMethods
    {
        public static bool In2DArrayBounds(this object[,] array, int x, int y)
        {
            if (x < array.GetLowerBound(0) ||
                x > array.GetUpperBound(0) ||
                y < array.GetLowerBound(1) ||
                y > array.GetUpperBound(1)) return false;
            return true;
        }
    }
