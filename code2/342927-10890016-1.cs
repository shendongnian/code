        /// <summary>
        /// Used to modify properties of an object returned from a LINQ query
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="input">The source</param>
        /// <param name="updater">The action to perform.</param>
        public static TSource Update<TSource>(this TSource input, Action<TSource> updater)
        {
            if (!updater.IsNull() && !input.IsNull())
            {
                updater(input);
            }
            return input;
        }
