    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      foreach (DataGridColumn column in dataGrid1.Columns)
      {
        // save the column.Width property to a user setting/file/registry/etc...
        // optionally save the displayindex as well...
      }
    } 
