    public static TResult Sample<TItem, TResult>(this IEnumerable<TItem> items, Func<TItem, TResult> gimmeThatValue)
    {
      var firstItem = items.First();
      return gimmeThatValue(firstItem);
    }
    
    var items = new []{new{Value1 = 1, Value2 = "Abc"}};
    int    value1 = items.Sample(i => i.Value1);
    String value2 = items.Sample(i => i.Value2.Substring(2, 1));
