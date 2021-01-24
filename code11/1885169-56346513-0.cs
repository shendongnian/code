    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "imgClick")
        {
           ImageButton btn = e.CommandSource as ImageButton;
           //Do what you need to do here
           string imgUrl = btn.ImageUrl;
    }
