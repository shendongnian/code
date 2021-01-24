    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get the index of the last changed checkbox
        int index = Convert.ToInt32(Request.Form["__EVENTTARGET"].Split('$').Last());
        //find the correct listitem in the checkboxlist
        ListItem item = CheckBoxList1.Items[index];
        //if the item is already in first position do nothing
        if (index == 0)
            return;
        //remove it from it's current position
        CheckBoxList1.Items.RemoveAt(index);
        //add the listitem at the top
        CheckBoxList1.Items.Insert(0, item);
    }
