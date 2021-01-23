    private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
    {
      YourObject obj = e.Row.Item as YourObject;
      if (obj != null)
      {
         //see obj properties
      }
    }
