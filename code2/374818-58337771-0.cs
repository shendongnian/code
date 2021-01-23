     protected void Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
           
            ModalPopupExtender ModalPopupExtenderLinkButton =
              e.Item.FindControl("ModalPopupExtenderLinkButton") as ModalPopupExtender;
            if (condition)
              e.Item.Controls.Remove(ModalPopupExtenderLinkButton);
        }
    }
