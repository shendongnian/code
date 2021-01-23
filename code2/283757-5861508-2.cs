       private List<int> dirtyRows = new List<int>();
       void HandleRowChanged(object sender, EventArgs args)
       {
          GridViewRow row = ((Control) sender).NamingContainer as GridViewRow;
          if (null != row && !dirtyRows.Contains(row.RowIndex))
          {
             dirtyRows.Add(row.RowIndex);
          }
       }
    
