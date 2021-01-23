    public static class ListExtension
    {
        public static int GetIndex<T>(this List<T> entity, T what, int find)
        {
            int found = 0;
            int index = -1;
            while ((index = entity.IndexOf(what, (index + 1))) != -1)
            {
                found++;
                if (found == find)
                    break;
            }
            return (index);
        }
    }
