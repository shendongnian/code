    static private void ResizeAutoSizeColumn(ListView listView, int autoSizeColumnIndex)
    {
      // Do some rudimentary (parameter) validation.
      if (listView == null) throw new ArgumentNullException("listView");
      if (listView.View != View.Details || listView.Columns.Count <= 0 || autoSizeColumnIndex < 0) return;
      if (autoSizeColumnIndex >= listView.Columns.Count)
        throw new IndexOutOfRangeException("Parameter autoSizeColumnIndex is outside the range of column indices in the ListView.");
    
      // Sum up the width of all columns except the auto-resizing one.
      int otherColumnsWidth = 0;
      foreach (ColumnHeader header in listView.Columns)
        if (header.Index != autoSizeColumnIndex)
          otherColumnsWidth += header.Width;
    
      // Calculate the (possibly) new width of the auto-resizable column.
      int autoSizeColumnWidth = listView.ClientRectangle.Width - otherColumnsWidth;
    
      // Finally set the new width of the auto-resizing column, if it has changed.
      if (listView.Columns[autoSizeColumnIndex].Width != autoSizeColumnWidth)
        listView.Columns[autoSizeColumnIndex].Width = autoSizeColumnWidth;
    }
