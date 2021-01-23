    public static int ProcessItems<T>(this IEnumerable<T> items, Func<T, int> processMethod)
    {
        foreach (var item in items)
        {
            try
            {
                return processMethod(item);
            }
            catch(Exception) {}
        }
        return -1;
    }
