    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DropDownList)sender).SelectedIndex < (int)ViewState["PreviousIndex"])
            {
                counter -= ((DropDownList)sender).SelectedIndex;
            }
            else
            {
                counter += ((DropDownList)sender).SelectedIndex;
            }
        }
