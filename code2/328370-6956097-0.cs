    public static class SampleExtensions
    {
        // The Random class is instantiated as singleton 
        // because it would give bad random values 
        // if instantiated on every call to RandomOrDefault method
        private static readonly Random RandomGenerator = new Random(unchecked((int)DateTime.Now.Ticks));
        public static T RandomOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            IEnumerable<T> filtered = source.Where(predicate);
            int count = 0;
            T selected = default(T);
            foreach (T current in filtered)
            {
                if (RandomGenerator.Next(0, ++count) == 0)
                {
                    selected = current;
                }
            }
            return selected;
        }
        public static T RandomOrDefault<T>(this IEnumerable<T> source)
        {
            return RandomOrDefault(source, element => true);
        }
    }
