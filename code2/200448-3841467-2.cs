    public static class ExtensionMethods
    {
        public static TCollection Append<TCollection, TItem>(this TCollection collection, TItem item)
            where TCollection : ICollection<TItem>
        {
            collection.Add(item);
            return collection;
        }
    }
