    void myRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e) {
        if (e.Item.ItemType == ListItemType.Header) {
            CheckBox cb = (CheckBox)e.Item.FindControl("selectAllCheckBox");
            bool isChecked = cb.Checked;
        }
    }
