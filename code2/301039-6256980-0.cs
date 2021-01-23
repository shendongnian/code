    public static class BindingViewListExtensions
    {
      public static void Where<T>(this BindingListView<T> list, Func<T, bool> function)
      {
        // I am not sure I like this, but we know it is a List<T>
        var lists = list.DataSource as List<T>;
        foreach (var item in lists.Where<T>(function))
        {
            Console.WriteLine("I got item {0}", item);
        }
      }
