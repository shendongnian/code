    public class ComboBoxSorterIdentifierItem
    {
      public List<SorterIdentifier> Items { get; }
      public override string ToString()
      {
        if ( Items == null || Items.Count == 0) return "";
        return Items[0].ToString();
      }
      public BookItem(List<SorterIdentifier> items)
      {
        Items = items;
      }
    }
