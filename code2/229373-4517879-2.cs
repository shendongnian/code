        public class EnumerableComparer<T> : IEqualityComparer<IEnumerable<T>> where T : IComparable<T>
        {
            public bool Equals(IEnumerable<T> first, IEnumerable<T> second)
            {
                if (first == second)
                    return true;
                if ((first == null) || (second == null))
                    return false;
    
                bool equal = first.ToHashSet().SetEquals(second);
                return equal;
            }
    
            public int GetHashCode(IEnumerable<T> enumerable)
            {
                return GetEnumerableHashCode(enumerable);
            }
    
            public static int GetEnumerableHashCode(IEnumerable<T> enumerable)
            {
                return enumerable.OrderBy(x => x).Aggregate(17, (current, val) => current*23 + val.GetHashCode());
            }
        }
