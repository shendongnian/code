    public static class ListExt
    {
        // O(1) 
        public static void RemoveBySwap<T>(this List<T> list, int index)
        {
            list[index] = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
        }
        // O(n)
        public static void RemoveBySwap<T>(this List<T> list, T item)
        {
            int index = list.IndexOf(item);
            RemoveBySwap(list, index);
        }
        // O(n)
        public static void RemoveBySwap<T>(this List<T> list, Predicate<T> predicate)
        {
            int index = list.FindIndex(predicate);
            RemoveBySwap(list, index);
        }
    }
