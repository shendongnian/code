    public static class NullExtensionMethods
    {
        public static bool HasNull(this IEnumerable collection)
        {
            foreach (var item in collection)
            {
                if (item == null)
                {
                    return true;
                }
            }
            return false;
        }
    }
