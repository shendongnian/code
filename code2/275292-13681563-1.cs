    /// <summary>
    /// Given two list, compare and extract differences
    /// http://stackoverflow.com/questions/5620266/the-opposite-of-intersect
    /// </summary>
    public class CompareList
    {
        /// <summary>
        /// Returns list of items that are in initial but not in final list.
        /// </summary>
        /// <param name="listA"></param>
        /// <param name="listB"></param>
        /// <returns></returns>
        public static IEnumerable<string> NonIntersect(
            List<string> initial, List<string> final)
        {
            //subtracts the content of initial from final
            //assumes that final.length < initial.length
            return initial.Except(final);
        }
        /// <summary>
        /// Returns the symmetric difference between the two list.
        /// http://en.wikipedia.org/wiki/Symmetric_difference
        /// </summary>
        /// <param name="initial"></param>
        /// <param name="final"></param>
        /// <returns></returns>
        public static IEnumerable<string> SymmetricDifference(
            List<string> initial, List<string> final)
        {
            IEnumerable<string> setA = NonIntersect(final, initial);
            IEnumerable<string> setB = NonIntersect(initial, final);
            // sum and return the two set.
            return setA.Concat(setB);
        }
    }
