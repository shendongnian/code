private ListViewItemComparer LviComparer = new ListViewItemComparer(); // Comparer Class
    // Override OnColumn Click
    protected override void OnColumnClick(ColumnClickEventArgs e)
    {
      if (e.Column == LviComparer.SortColumn)
      {
        if (LviComparer.Order == SortOrder.Ascending)
        {
          LviComparer.Order = SortOrder.Descending;
        }
        else
        {
          LviComparer.Order = SortOrder.Ascending;
        }
      }
      else
      {
        LviComparer.SortColumn = e.Column;
        LviComparer.Order = SortOrder.Ascending;
      }
      this.Sort();
      base.OnColumnClick(e);
    }
