    protected void myControl_ItemDataBound(object sender, ControlItemEventArgs e)
    {
       if (e.Item.ListItemType == ListItemType.Header)
       {
          foreach (TableCell tc in e.Item.Cells)
          {
             tc.Text = Localization.GetString(string.Format("{0}.Header", tc.Text), LocalResourceFile);
          }
       }
    }
