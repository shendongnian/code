        private static Random rnd = new Random();
        /// <summary>
        /// Chooses one of the items at random.
        /// 
        /// Returns default if there are no items.
        /// </summary>
        public static T RandomOrDefault<T>(this IEnumerable<T> source)
        {
            // We need the count:
            var buffer = source as ICollection<T> ?? source.ToList(); // (iterate only once)
            var itemCount = buffer.Count;
            if (itemCount == 0)
            {
                return default(T);
            }
            var index = rnd.Next(itemCount);
            return buffer.ElementAt(index);
        }
        /// <summary>
        /// Randomizes the order of the elements of a sequence. 
        /// </summary>
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            // This code is an implementation of the Fisherâ€“Yates shuffle.
            // The code was obtained from:
            // https://stackoverflow.com/questions/1287567/c-is-using-random-and-orderby-a-good-shuffle-algorithm/1665080#1665080
            T[] elements = source.ToArray();
            // Note i > 0 to avoid final pointless iteration
            for (int i = elements.Length - 1; i > 0; i--)
            {
                // Swap element "i" with a random earlier element it (or itself)
                int swapIndex = rnd.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
                // we don't actually perform the swap; we can forget about the
                // swapped element because we already returned it.
            }
            // there is one item remaining that was not returned - we return it now
            yield return elements[0];
        }
