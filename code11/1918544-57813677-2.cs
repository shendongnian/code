    public static class Extensions
    {
        public static double GetMaxInRange(this Dictionary<int, double> data, int minKey, int maxKey)
        {
            return data.Where(x => x.Key >= minKey && x.Key <= maxKey).Max(y => y.Value);
        }
        public static double GetMinInRange(this Dictionary<int, double> data, int minKey, int maxKey)
        {
            return data.Where(x => x.Key >= minKey && x.Key <= maxKey).Min(y => y.Value);
        }
    }
