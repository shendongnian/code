    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
          GridView1.PageIndex = e.NewPageIndex;
          GridView1.DataBind();
    }
    public void GridView1_RowEditing(Object sender, GridViewEditEventArgs e)
    {
      //do your code here
    }
