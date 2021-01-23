    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
     if (e.CommandName == "SaveDescription")
        {
        DataListItem item = ((DataListItem)((ImageButton)e.CommandSource).NamingContainer);
        TextBox description = (TextBox)item.FindControl("description");
        description.Text // return your text 
        }
    }
