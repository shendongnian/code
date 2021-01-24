    /// <summary>
    /// A generic Comparer depends on the Assumption that both types have an Id property
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class IdEqualityComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T Item1, T Item2)
        {
            if (Item2 == null && Item1 == null)
                return true;
            else if (Item1 == null || Item2 == null)
                return false;
            var id1 = Item1.GetType().GetProperty("Id").GetValue(Item1, null).ToString();
            var id2 = Item2.GetType().GetProperty("Id").GetValue(Item2, null).ToString();
            if (id1==id2)
                return true;
            else
                return false;
        }
        public int GetHashCode(T Item)
        {
            var id = Item.GetType().GetProperty("Id").GetValue(Item, null).ToString();
            return id.GetHashCode();
        }
    }
