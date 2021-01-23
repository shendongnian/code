    public static class TExtensions
        {
            public static List<T> ToList<T>(this IEnumerable<T> collection)
            {
                return new List<T>(collection);
            }
    
            public static BindingList<T> ToBindingList<T>(this IEnumerable<T> collection)
            {
                return new BindingList<T>(collection.ToList());
            }
        }
