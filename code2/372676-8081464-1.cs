    public class ListEqualityComparer<T> : IEqualityComparer<List<T>>
    {
        public bool Equals(List<T> list1, List<T> list2)
        {
            return list1.SequenceEquals(list2);
        }
  
        public int GetHashCode(List<T> list)
        {
            if(list != null && list.Length > 0)
            {
                var hashcode = list[0].GetHashCode();
                for(var i = 1; i <= list.Length; i++)
                    hashcode ^= list[i].GetHashCode();
                return hashcode;
            }
            return 0;
        }
    }
