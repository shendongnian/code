    public class ItemWithSubItem:ListViewItem
    {
      public ItemWithSubItem(string ItemText, string SubItemText)
      {
         this.Text=ItemText;
         this.SubItems.Add(SubItemText);
      }
    }
