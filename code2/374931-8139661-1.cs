    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = ((DropDownList)sender).SelectedIndex;
            if (selectedIndex < (int)ViewState["PreviousIndex"])
            {
                counter -= ((DropDownList)sender).SelectedIndex;
            }
            else
            {
                counter += ((DropDownList)sender).SelectedIndex;
            }
            // update the index
            ViewState["PreviousIndex"] = selectedIndex;
        }
