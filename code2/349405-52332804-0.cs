    public static class EnumerableExtensions {
        public static bool IsLast<T>(this List<T> items, T item)
            {
                if (items.Count == 0)
                    return false;
                T last = items[items.Count - 1];
                return item.Equals(last);
            }
        }
