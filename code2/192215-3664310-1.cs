    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (Repeater1.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                HtmlGenericControl noRecordsDiv = (e.Item.FindControl("NoRecords") as HtmlGenericControl);
                if (noRecordsDiv != null) {
                  noRecordsDiv.Visible = true;
                } 
            }
        }
    }
