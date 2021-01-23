    protected void dl1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        DataList dl2 = (DataList)e.Item.FindControl("dl2");
        ... // load DataTable
        dl2.DataSource = dt;
        dl2.DataBind();
    }
