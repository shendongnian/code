    public static TList Anything<TList, TItem>(this TList list, TItem item)
        where TList : IList<TItem>
    {
        list.Add(item);
        return list;
