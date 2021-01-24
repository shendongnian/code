        public static Dictionary<string, object> GetDiffs(
            IDictionary<string, object> source,
            IDictionary<string, object> target)
        {
            return source
                .Where(x => !x.Value.Equals(target[x.Key]))
                .ToDictionary(
                    x => x.Key,
                    x => x.Value);
        }
