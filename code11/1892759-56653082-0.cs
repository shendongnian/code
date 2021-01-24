    // Note that although it says IList here, this method actually returns a List<T> at runtime
    // We don't know the actual type of the list at compile time. The best we know
    // is that it is some kind of a list.
    static System.Collections.IList ConvertListToType<T>(Type type, List<T> list) {
        Type constructedListType = typeof(List<>).MakeGenericType(type);
        var newList = (System.Collections.IList)Activator.CreateInstance(constructedListType);
        list.ForEach(x => newList.Add(x));
        return newList;
    }
