        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
        {
            int nGroups = (int)Math.Ceiling(list.Count() / (double)parts);
            var groups = Enumerable.Range(0, nGroups);
            return groups.Select(g => list.Skip(g * parts).Take(parts));
        }
