    protected void LV_ItemCreated(object sender, ListViewItemEventArgs e)
    {
      // Retrieve the current item.
      ListViewItem item = e.Item;
    
      // Verify if the item is a data item.
      if (item.ItemType == ListViewItemType.DataItem && cb.Checked)
      {
        ImageButton btndel = (ImageButton)item.FindControl("btnDelete");
        btndel.ImageUrl = "~/images/activate.png";
      }
    }
