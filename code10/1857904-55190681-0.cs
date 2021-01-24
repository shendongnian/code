    public static ICollectionExtensions
    {
        public static AddNew<T>(this ICollection<T> collection)
            where T : new()
        {
            var newItem = new T();
            collection.Add(newItem);
        }
        ...
    } 
