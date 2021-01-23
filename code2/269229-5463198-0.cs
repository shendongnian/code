    protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "view_frnd")
        {
            Response.Write(e.CommandArgument);
        }
    }
