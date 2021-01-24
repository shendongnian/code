    public static class IfNotNull
    {
        public static void ThenUpdate<T>(T item, Action<T> update)
            where T : class
        {
            if (item != null)
            {
                update(item);
            }
        }
    }
