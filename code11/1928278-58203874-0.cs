    public class ComboBoxSorterIdentifierItem
    {
      public List<SorterIdentifier> Item { get; }
      public override string ToString()
      {
        if ( Item == null || Item.Count == 0) return "";
        return Item[0].ToString();
      }
      public BookItem(List<SorterIdentifier> item)
      {
        Item = item;
      }
    }
