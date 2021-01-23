    public static IOrderedEmumerable<MyType> OrderForDisplay (this IEnumerable<MyType> input)
    {
      return
        input
        .OrderBy(item => item.Status)
        .ThenByDescending(item => item.Status == 1 ? DateTime.MaxDate : item.date);
    }
