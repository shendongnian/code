    var temp = original.Shuffle().ToArray();
    var sixty = temp.Take((int)(temp.Length * 0.6)).ToArray();
    var thirty = temp.Skip(sixty.Length).Take((int)(temp.Length * 0.3)).ToArray();
    var ten = temp.Skip(sixty.Length + thirty.Length).ToArray();
    // ...
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var rng = new Random();
            return source.Shuffle(rng);
        }
        public static IEnumerable<T> Shuffle<T>(
            this IEnumerable<T> source, Random rng)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (rng == null) throw new ArgumentNullException("rng");
            var buffer = source.ToList();
            for (int n = 0; n < buffer.Count; n++)
            {
                int k = rng.Next(n, buffer.Count);
                yield return buffer[k];
                buffer[k] = buffer[n];
            }
        }
    }
