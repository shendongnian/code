    public class ListEqualityComparer<T> : IEqualityComparer<List<T>>
    {
        public bool Equals(List<T> list1, List<T> list2)
        {
            return list1.SequenceEquals(list2);
        }
  
        public int GetHashCode(List<T> list)
        {
            return list.GetHashCode();
        }
    }
