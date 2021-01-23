    public static class ExtensionsForInt32
    {
        public static bool IsBetween (this int val, int low, int high)
        {
               return val > low && val < high;
        }
    }
