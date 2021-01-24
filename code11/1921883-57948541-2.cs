    public static class CollectionExtension
    {
        public const double DEFAULT_SAFETY_MARGIN = 0.01;
        private static readonly Random _defaultRandomSrc = new Random();
        /// <summary>
        /// Picks random items from a list, will only allow you to take up to the safety margin of items.
        /// </summary>
        /// <param name="source">The source list.</param>
        /// <param name="count">The number of items to take. This must be less than or equal to
        /// <see cref="DEFAULT_SAFETY_MARGIN"/> * <paramref name="count"/>.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> that will contain <paramref name="count"/> items.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="count"/> is more
        /// than <see cref="DEFAULT_SAFETY_MARGIN"/> * <paramref name="count"/>.</exception>
        public static IEnumerable<T> PickFewRandom<T>(this IList<T> source, int count)
        {
            if ((double)count / source.Count > DEFAULT_SAFETY_MARGIN)
                throw new ArgumentOutOfRangeException(nameof(count), count,
                    $"The number of items you are taking must be less than {source.Count * DEFAULT_SAFETY_MARGIN}");
            //Random is not thread safe so when we generate the seed from the
            //static random instance we must do a lock.
            int randomSeed;
            lock (_defaultRandomSrc)
            {
                randomSeed = _defaultRandomSrc.Next();
            }
            // We use a separate method here because if the "yield return" was in this method the
            // ArgumentOutOfRangeException would not get thrown till the user tried to enumerate
            // the result instead of when calling the function.
            return PickFewRandomInternal(source, count, randomSeed);
        }
        private static IEnumerable<T> PickFewRandomInternal<T>(IList<T> source, int count, int randomSeed)
        {
            //We pass in randomSeed so if you run foreach on the returned IEnumerable multiple times it will return the same order each time.
            var random = new Random(randomSeed);
            var pickedItems = new HashSet<int>(count);
            for (int i = 0; i < count; i++)
            {
                int index;
                // This looping is only safe to do because there is a low probability of duplicates,
                // if we where taking more items then this function could take a long time to run.
                do
                {
                    index = random.Next(count);
                } while (!pickedItems.Add(index));
                yield return source[index];
            }
        }
    }
