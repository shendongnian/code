    /// <summary>
    /// Prepares the range specifier.
    /// </summary>
    private void PrepareRangeSpecifier()
    {                  
        //clear the items from the end range list
        ddlEndDayOfWeek.Items.Clear();
        if (pnlEndDayOfWeek.Visible)
        {
            foreach (RadComboBoxItem item in ddlStartDayOfWeek.Items)
            {
                //insert the list items from the start range list
                if (item.Index > ddlStartDayOfWeek.SelectedIndex)
                    ddlEndDayOfWeek.Items.Add(new RadComboBoxItem(item.Text, item.Value));
            }
            //set end range panel visibility
            pnlEndDayOfWeek.Visible = ddlEndDayOfWeek.Items.Count > 0;
        }
        //if the end range has any items
        if (ddlEndDayOfWeek.Items.Count > 0)
            ddlEndDayOfWeek.Items.FirstOrDefault().Selected = true;
    } 
