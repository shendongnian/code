    public static class Extensions
    {
        public static IEnumerable<List<T>> GetNonAdjacentSubsets<T>(
            this IEnumerable<T> source, 
            int min_distance, //minimum gap between numbers
            List<T> subset = null)
        {
            for (int i = 0; i < source.Count(); i++)
            {
                var new_subset = new List<T>(subset ?? Enumerable.Empty<T>())
                {
                    source.ElementAt(i)
                };
                if (new_subset.Count > 1) //return subsets of more than one element
                    yield return new_subset;
                if (source.Count() < 2) //end of list reached
                    yield break;
                foreach (var ss in source.Skip(i + min_distance).GetNonAdjacentSubsets(min_distance, new_subset))
                    yield return ss;
            }
        }
    }
