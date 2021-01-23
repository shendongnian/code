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
