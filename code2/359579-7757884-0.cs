    protected void CheckBox_selectColumns_SelectedIndexChanged(object sender, EventArgs e)         
    {             
        if (CheckBox_selectColumns.SelectedValue != "")
        {
            foreach (ListItem listItem in CheckBox_SelectAll.Items)
            {
                listItem.Selected = false;
            }
        }
    }
    protected void CheckBox_SelectAll_CheckChanged(object sender, EventArgs e)
    {
    
        if (CheckBox_SelectAll.SelectedValue != "")
        {
            foreach (ListItem listItem in CheckBox_selectColumns.Items)
            {
                listItem.Selected = false;
            }
        }
    }
