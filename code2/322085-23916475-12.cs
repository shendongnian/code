    public static void ReplaceItem<T>(this Collection<T> col, Func<T, bool> match, T newItem)
    {
        var oldItem = col.FirstOrDefault(i => match(i));
        var oldIndex = col.IndexOf(oldItem);
        col[oldIndex] = newItem;
    }
