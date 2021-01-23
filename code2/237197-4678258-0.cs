    public class MyAutoCompleteStringCollection : AutoCompleteStringCollection
    {
      public MyAutoCompleteStringCollection(IEnumerable items)
      {
         this.AddRange(items.ToArray())
      }
    }
