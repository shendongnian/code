    public static List<T> Append(this List<T> list, T item)
    {
      list.Add(item);
      return self;
    }
