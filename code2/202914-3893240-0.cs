        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
        {
            var groups = Enumerable.Range(0, (int)Math.Ceiling(list.Count() / (double)parts));
            return groups.Aggregate(new List<IEnumerable<T>>(), (acc, next) => 
                {
                    acc.Add(list.Skip(next * parts).Take(parts));
                    return acc;
                });
        }
