                /// <summary>
            /// Returns an ordered collection by key selector (property expression) using alpha numeric comparer
            /// </summary>
            /// <typeparam name="T">The item type in the ienumerable</typeparam>
            /// <typeparam name="TKey">The type of the key selector (property to order by)</typeparam>
            /// <param name="coll">The source ienumerable</param>
            /// <param name="keySelector">The key selector, use a member expression in lambda expression</param>
            /// <returns></returns>
            public static IEnumerable<T> OrderByMember<T, TKey>(this IEnumerable<T> coll, Func<T, TKey> keySelector)
            {
                var result = coll.OrderBy(keySelector, new AlphanumericComparer<TKey>());
                return result;
            }
