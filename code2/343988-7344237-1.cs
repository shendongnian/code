        public static IEnumerable<List<T>> GetPermutations<T>(IEnumerable<T> items)
        {
            if (items.Count() == 0) 
                yield return new List<T>();
            foreach (var i in items)
            {
                var copy = new List<T>(items);
                copy.Remove(i);
                foreach(var rest in GetPermutations(copy))
                {
                    rest.Insert(0, i);
                    yield return rest;
                }
            }
        }
        public static IEnumerable<IEnumerable<T>>  GetEnumPermutations<T>(IEnumerable<T> items )
        {
            return GetPermutations(items);
        }
