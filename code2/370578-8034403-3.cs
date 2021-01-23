    void RadGrid1_PreRender(object sender, EventArgs e)
    {
      foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
      {
        if (item.HasChildItems)
        {
          bool flag = item.Expanded;
          item.Expanded = true;
          int csum = 0;
          foreach (GridDataItem citem in item.ChildItem.NestedTableViews[0].Items)
          {
            csum += Convert.ToInt32((citem.FindControl("Label2") as Label).Text);
          }
         
          GridFooterItem cfooter = (GridFooterItem)item.ChildItem.NestedTableViews[0].GetItems(GridItemType.Footer)[0];
          cfooter["Name1"].Text = csum.ToString();
          item.Expanded = flag;
        }
      }
    }
