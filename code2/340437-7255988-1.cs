    string dataItem = (string)e.Item.DataItem;
    if (dataItem == "Item 1")
    {
        ((HtmlTableRow)e.Item.FindControl("prodName")).Visible = false;   
    }
