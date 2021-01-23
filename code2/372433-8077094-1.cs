    void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var label = e.Item.FindControl("Label1") as Label;
        if (label != null)
        {
            var selectButton = e.Item.FindControl("SelectButton") as Button;
            label.Attributes["onmouseover"] = ClientScript.GetPostBackEventReference(selectButton, "");
        }
    }
