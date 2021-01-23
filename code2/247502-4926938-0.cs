    var list = new ArrayList(); // (or a newer, generic container, like List<T>)
    ...
    foreach (var item in list)
    {
        string str8 = Conversions.ToString(item);
        ...
    }
