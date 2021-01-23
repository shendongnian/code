    public static class Extensions
    {
        public static IList<TResult> GetBitsAs<TResult>(this BitArray bits) where TResult : struct
        {
            return GetBitsAs<TResult>(bits, 0);
        }
        /// <summary>
        /// Gets the bits from an BitArray as an IList combined to the given type.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="bits">An array of bit values, which are represented as Booleans.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        /// <returns>An read-only IList containing all bits combined to the given type.</returns>
        public static IList<TResult> GetBitsAs<TResult>(this BitArray bits, int index) where TResult : struct
        {
            var instance = default(TResult);
            var type = instance.GetType();
            int sizeOfType = Marshal.SizeOf(type);
            int arraySize = (int)Math.Ceiling(((bits.Count - index) / 8.0) / sizeOfType);
            var array = new TResult[arraySize];
            bits.CopyTo(array, index);
            return array;
        }
    }
