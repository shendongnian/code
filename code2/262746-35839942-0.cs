        /// <summary>
        ///   Checks whether all items in the enumerable are same (Uses <see cref="object.Equals(object)" /> to check for equality)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns>Returns true if all items in the enumerable are same (equal to each other) otherwise false.</returns>
        public static bool AreAllSame<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            var enumerator = enumerable.GetEnumerator();
            var toCompare = default(T);
            if (enumerator.MoveNext())
            {
                toCompare = enumerator.Current;
            }
            while (enumerator.MoveNext())
            {
                if (!toCompare.Equals(enumerator.Current))
                {
                    return false;
                }
            }
            return true;
        }
