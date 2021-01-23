    public static class ListExtensions
    {
        public static void MoveUp<T>(this List<T> list, T item)
        {
            int index = list.IndexOf(item);
            if (index == -1)
            {
                // item is not in the list
                throw new ArgumentOutOfRangeException("item");
            }
            if (index == 0)
            {
                // item is on top
                return;
            }
            list.RemoveAt(index);
            list.Insert(index - 1, item);
        }
        public static void MoveDown<T>(this List<T> list, T item)
        {
            int index = list.IndexOf(item);
            if (index == -1)
            {
                // item is not in the list
                throw new ArgumentOutOfRangeException("item");
            }
            if (index == list.Count - 1)
            {
                // item is no bottom
                return;
            }
            list.RemoveAt(index);
            list.Insert(index + 1, item);
        }
    }
