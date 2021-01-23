    protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "view_frnd")
        {
            // get the link button in the row selected
            LinkButton LinkButton3 = (LinkButton)e.Item.FindControl("LinkButton3");
            // get its text
            Response.Write(LinkButton3.Text);
        }
    }
