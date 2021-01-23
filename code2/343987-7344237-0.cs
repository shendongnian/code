        public static IEnumerable<List<T>> GetPermutations<T>(List<T> items)
        {
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
