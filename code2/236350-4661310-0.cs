    static void Main(string[] args)
    {
      IList list = foobar(typeof(string));
      list.Add("foo");
      list.Add("bar");
      foreach (string s in list)
        Console.WriteLine(s);
      Console.ReadKey();
    }
    private static IList foobar(Type t)
    {
      var listType = typeof(List<>);
      var constructedListType = listType.MakeGenericType(t);
      var instance = Activator.CreateInstance(constructedListType);
      return (IList)instance;
    }
