    public static class ListUtils
    {
        public static object CreateListOfPersistent(Type elementType)
        {
            if (!typeof(Persistent).IsAssignableFrom(elementType))
                throw new ArgumentException("elementType must derive from Persistent.", "elementType");
            var listType = typeof(ListOfPersistent<>).MakeGenericType(elementType);
            return Activator.CreateInstance(listType);
        }
    }
    // ...
    if (Extensions.IsPersistent<T>())
        list = (IList<T>) ListUtils.CreateListOfPersistent(typeof(T));
    else
        list = new ListOfNonPersistent<T>();
