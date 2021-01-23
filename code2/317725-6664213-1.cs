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
            list.Swap(index, index - 1);
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
            list.Swap(index, index + 1);
        }
        private static void Swap<T>(this List<T> list, int i1, int i2)
        {
            T temp = list[i1];
            list[i1] = list[i2];
            list[i2] = temp;
        }
    }
