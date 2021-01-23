     public class ListViewItemComparer : IComparer  {
      public int SortColumn  {  get ; private set ; }
      public SortOrder Order {  get ; private set ; }
      private CaseInsensitiveComparer objectCompare = new CaseInsensitiveComparer();
      public int Compare(object x, object y)
      {
        int compResult = 0;
        ListViewItem lviX, lviY;
        lviX = (ListViewItem)x;
        lviY = (ListViewItem)y;
        compResult = CompareString(lviX, lviY);
				if (Order == SortOrder.Ascending)
        {
          return compResult;
        }
				else if (Order == SortOrder.Descending)
        {
          return (-compResult);
        }
        else
        {
          return 0;
        }
      }
    private int CompareString(ListViewItem lviX, ListViewItem lviY)
    {
      try
      {
				int compareResult = objectCompare.Compare(lviX.SubItems[SortColumn].Text, lviY.SubItems[SortColumn].Text);
        return compareResult;
      }
      catch (IndexOutOfRangeException ex)
      {
        Console.WriteLine(ex.Message);
        return 0;
      }
    } }
