    public static T ToList<T>(this IEnumerable baseList) where T : IList,new()
    {
        T newList = new T();
        foreach (object obj in baseList)
        {
            newList.Add(obj);
        }
        return (newList);
    }
