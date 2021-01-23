    private void CreateGridView(string type, SystemPage page, Cell parent)
    {
       GridView services = new GridView();
       ...
       services.RowEditing += new GridViewEditEventHandler(services_RowEditing);
       parent.Add(services);
       services.DataSource = list;
       services.DataBind();
    }
    protected void PageSettings_DataBound(object sender, GridViewRowEventArgs e)
    {
       ....
    
       SystemPage SysPage = e.Row.DataItem as SystemPage;
       // add the row first to the page
       row.Cells.Add(cell);
       Table table = e.Row.Parent as Table;
       table.Rows.AddAt(e.Row.RowIndex + 2, row);
       CreateGridView("WebServices", sysPage, cell);
    }
