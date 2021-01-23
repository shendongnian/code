    public Type GetListItemType<T>(List<T> list)
    {
      Type type = list.GetType();
      while (type != typeof(List<T>))
        type = type.BaseType;
      return type.GetGenericArguments().Single();
    }
    var list = new List<int>();
    var subList = new SubList();
    Console.WriteLine(GetListItemType(list)); // System.Int32
    Console.WriteLine(GetListItemType(subList)); // System.Int32
