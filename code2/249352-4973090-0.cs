    public static T[] GetUnderlyingArray<T>(this List<T> list)
    {
        var field = list.GetType().GetField("_items",
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic);
        return (T[])field.GetValue(list);
    }
