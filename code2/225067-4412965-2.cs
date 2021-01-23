    public static class ArrayExtensions {
        public static bool ArrayAndIndexesAreValid(
            T[] array,
            int startInclusive,
            int endExclusive
        ) {
        return array != null &&
               array.Length > 0 &&
               startInclusive >= 0 && startInclusive < array.Length &&
               endExclusive >= 1 && endExclusive <= array.Length &&
               startInclusive < endExclusive;
        }
        public static IEnumerable<T> Slice<T>(
            this T[] array,
            int startInclusive,
            int endExclusive
        ) {
            Contract.Requires<ArgumentException>(ArrayAndIndexesAreValid(
                array,
                startInclusive,
                endExclusive)
            );
            for (int index = startInclusive; index < endExclusive; index++) {
                yield return array[index];
            }
        }
        public static T MinimumInIndexRange<T>(
            this T[] array,
            int startInclusive,
            int endExclusive
        ) where T : IComparable {
            Contract.Requires<ArgumentException>(ArrayAndIndexesAreValid(
                array,
                startInclusive,
                endExclusive)
            );
            return array.Slice(startInclusive, endExclusive).Min();
        }
        public static T MaximumInIndexRange<T>(
            this T[] array,
            int startInclusive,
            int endExclusive
        ) where T : IComparable {
            Contract.Requires<ArgumentException>(ArrayAndIndexesAreValid(
                array,
                startInclusive,
                endExclusive)
            );
            return array.Slice(startInclusive, endExclusive).Max();
        }
    }
