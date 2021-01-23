    public static IList<T> Append(this IList<T> list, T item)
    {
      list.Add(item);
      return self;
    }
