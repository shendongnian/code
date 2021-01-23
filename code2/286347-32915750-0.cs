    public static class EnumerableExtensions
            {
    
                /// <summary>
                /// Returns a ienumerable which is distinct by a given property key selector. If a custom equality 
                /// comparer is to be used, pass this in as the comparer. By setting the comparer default to null,
                /// the default comparer is used. 
                /// </summary>
                /// <typeparam name="T">The item type in the ienumerable</typeparam>
                /// <typeparam name="TKey">The type of the key selector (property to disinct elements by)</typeparam>
                /// <param name="coll">The source ienumerable</param>
                /// <param name="keySelector">The key selector, use a member expression in a lambda expression</param>
                /// <param name="comparer">Custom comparer to use, pass in null here to specify that default comparer is used,
                /// however, this is default set to null and not required parameter</param>
                /// <returns></returns>
                public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> coll, Func<T, TKey> keySelector,
                    IEqualityComparer<TKey> comparer = null)
                {
                    if (coll == null)
                        throw new ArgumentNullException("coll");
                    if (keySelector == null)
                        throw new ArgumentNullException("keySelector");
    
                    var result = coll.GroupBy(keySelector, comparer).Select(g => g.First()).ToList();
                    return new List<T>(result).AsEnumerable();
                }
    
            }
    
