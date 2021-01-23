    public static class StorageExtentions
        {
            public static T Get<T>(this Hashtable table, object key)
            {
                return (T) table[key];
            }
        }
