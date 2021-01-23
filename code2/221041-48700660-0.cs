        public static IList<IList<T>> Permutation<T>(ImmutableList<ImmutableList<T>> dimensions)
        {
            IList<IList<T>> result = new List<IList<T>>();
            Step(ImmutableList.Create<T>(), dimensions, result);
            return result;
        }
        private static void Step<T>(ImmutableList<T> previous, 
            ImmutableList<ImmutableList<T>> rest, 
            IList<IList<T>> result)
        {
            if (rest.IsEmpty)
            {
                result.Add(previous);
                return;
            }
            var first = rest[0];
            rest = rest.RemoveAt(0);
            foreach (var label in first)
            {
                Step(previous.Add(label), rest, result);
            }
        }
