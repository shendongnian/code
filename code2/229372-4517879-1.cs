    using System.Collections.Generic;
    using System.Linq;
    using System;
    
    namespace Partitions.Tests
    {
        public class PartitionComparer : IEqualityComparer<IEnumerable<IEnumerable<int>>>
        {
            readonly IEqualityComparer<IEnumerable<int>> _enumerableComparer;
    
            public PartitionComparer(bool checkInternalOrder)
            {
                if (checkInternalOrder)
                    _enumerableComparer = new OrderedEnumerableComparer();
                else
                    _enumerableComparer = new EnumerableComparer<int>();
            }
    
            public bool Equals(IEnumerable<IEnumerable<int>> partition1, IEnumerable<IEnumerable<int>> partition2)
            {
                if (partition1 == partition2)
                    return true;
                if ((partition1 == null) || (partition2 == null))
                    return false;
    
                var partition1Ordered = partition1.OrderBy(part => part.Min());
                var partition2Ordered = partition2.OrderBy(part => part.Min());
    
                return partition1Ordered.SequenceEqual(partition2Ordered, _enumerableComparer);
            }
    
            public int GetHashCode(IEnumerable<IEnumerable<int>> partition)
            {
                return partition.OrderBy(part => part.Min()).Aggregate(17,
                                                                       (current, part) =>
                                                                       current*23 +
                                                                       EnumerableComparer<int>.GetEnumerableHashCode(part));
            }
        }
    
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
    
        public class OrderedEnumerableComparer : IEqualityComparer<IEnumerable<int>>
        {
            public bool Equals(IEnumerable<int> first, IEnumerable<int> second)
            {
                if (first == second)
                    return true;
                if ((first == null) || (second == null))
                    return false;
    
                return first.SequenceEqual(second);
            }
    
            public int GetHashCode(IEnumerable<int> enumerable)
            {
                return enumerable.Aggregate(17, (current, val) => current*23 + val.GetHashCode());
            }
        }
    }
