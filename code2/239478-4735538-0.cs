    public class OneClass
    {
      private List<object> items;
      public List<object> Items { get { return items; } }
      public void AddOne(object item)
      {
        items.Add(item);
      }
    }
