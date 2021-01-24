        public static IEnumerable<Dictionary<string, object>> CompareResults(
            IEnumerable<Dictionary<string, object>> source,
            IEnumerable<Dictionary<string, object>> target)
        {
            for (var i = 0; i < source.Count(); i++)
            {
                // If there is no entry for the current index, complete dictionary from source will be returned.
                if (i >= target.Count())
                {
                    yield return source.ElementAt(i);
                    continue;
                }
                
                // Assuming you want to compare at the same index.
                yield return GetDiffs(
                    source.ElementAt(i),
                    target.ElementAt(i));
            }
        }
