    public static class Extensions
    {
        public static KeyValuePair<int, double> GetMaxInRange(this Dictionary<int, double> data, int minKey, int maxKey)
        {
            return data.Where(x => x.Key >= minKey && x.Key <= maxKey).OrderByDescending(y => y.Value).FirstOrDefault();
        }
        public static KeyValuePair<int, double> GetMinInRange(this Dictionary<int, double> data, int minKey, int maxKey)
        {
            return data.Where(x => x.Key >= minKey && x.Key <= maxKey).OrderBy(y => y.Value).FirstOrDefault();
        }
    }
