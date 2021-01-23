    if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    {
        HiddenField hf = (HiddenField)e.Item.FindControl("hfYear");
        DataList dl = (DataList)e.Item.FindControl("yourDataListID");
        yourDataListBindMethod(hf.Value);
    }
