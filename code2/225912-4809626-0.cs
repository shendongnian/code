    protected void level1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
      var listView2 = (ListView) e.Item.FindControl("level2");
      listView2.ItemDataBound += level2_ItemDataBound;
      listView2.DataSource = myDataSource;
      listView2.DataBind();
    }
    
    protected void level2_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
      var listView3 = (ListView) e.Item.FindControl("level3");
      listView3.DataSource = myDataSource;
      listView3.DataBind();
    }
