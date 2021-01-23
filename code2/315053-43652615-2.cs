        public static void DisposeItemsInList<T>(this IList<T> list) where T : IDisposable
        {
            DeleteItemsInList(list, item => item.Dispose());
        }
        public static void DeleteItemsInList<T>(this ICollection<T> list, Action<T> delete)
        {
            if (list is IList && !((IList)list).IsFixedSize)
            {
                while (list.Count > 0)
                {
                    T last = list.Last();
                    list.Remove(last);
                    delete?.Invoke(last);
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    delete?.Invoke(list.ElementAt(i));
                }
            }
        }
