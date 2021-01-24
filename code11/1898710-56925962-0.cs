        public static ImmutableList<T> Remove<T>(this ImmutableList<T> immutableList, T item, out bool found)
        {
            found = false;
            if (immutableList.Contains(item))
            {
                found = true;
                return immutableList.Remove(item);
            }
            return immutableList;
        }
