    public class RowItem
    {
      public RowItem()
      {
        this.ColumnItems = new ObservableCollection<ColumnItem>();
      }
      public ObservableCollection<ColumnItem> ColumnItems { get; }
    }
