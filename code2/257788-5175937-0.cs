    public class DeltaSet<T>
    {
        public ISet<T> FirstItems { get; private set; }
        public ISet<T> SecondItems { get; private set; }
        public ISet<Tuple<T, T>> IntersectedItems { get; private set; }
        public static DeltaSet<T> GetDeltaSet<T, U>(IDictionary<U, T> first,
                                                    IDictionary<U, T> second)
        {
            var firstUniques = new HashSet<T>(
                first.Where(x => !second.ContainsKey(x.Key)).Select(x => x.Value));
            var secondUniques = new HashSet<T>(
                second.Where(x => !first.ContainsKey(x.Key)).Select(x => x.Value));
            var intersection = new HashSet<Tuple<T, T>>(
                second.Where(x => first.ContainsKey(x.Key)).Select(x =>
                    Tuple.Create(first[x.Key], x.Value)));
            return new DeltaSet<T> { FirstItems = firstUniques,
                                     SecondItems = secondUniques,
                                     IntersectedItems = intersection };
        }
        public static DeltaSet<IDClass> GetDeltas(IEnumerable<IDClass> first,
                                                  IEnumerable<IDClass> second)
        {
            return GetDeltaSet(first.ToDictionary(x => x.ID),
                               second.ToDictionary(x => x.ID));
        }
    }
