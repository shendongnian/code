    public static class Extensions
    {
        public static T FindFirstAfterIndex<T>(this List<T> list, int index, T item)
            where T :IComparable
        {
            return list.Skip<T>(index).Where<T>(result => result.CompareTo(item)==0).First<T>();
        }
    }
