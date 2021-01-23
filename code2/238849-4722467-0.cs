    static class ListExtensions
    {
        public static bool MoveToFront<T>(this List<T> list, Predicate<T> match)
        {
            int idx = list.FindIndex(match);
            if (idx != -1)
            {
                if (idx != 0) // move only if not already in front
                {
                    T value = list[idx]; // save matching value
                    list.RemoveAt(idx); // remove it from original location
                    list.Insert(0, value); // insert in front
                }
                return true;
            }
            return false; // matching value not found
        }
    }
