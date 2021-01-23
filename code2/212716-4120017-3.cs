    var temp = original.Shuffle().ToArray();
    var sixty = temp.Take((int)(temp.Length * 0.6)).ToArray();
    var thirty = temp.Skip(sixty.Length).Take((int)(temp.Length * 0.3)).ToArray();
    var ten = temp.Skip(sixty.Length + thirty.Length).ToArray();
    // ...
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.Shuffle(new Random());
        }
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (rng == null) throw new ArgumentNullException("rng");
            return source.ShuffleIterator(rng);
        }
        private static IEnumerable<T> ShuffleIterator<T>(
            this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];
                buffer[j] = buffer[i];
            }
        }
    }
