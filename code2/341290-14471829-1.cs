    protected void drpOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            RepeaterItem item = (RepeaterItem)ddl.NamingContainer;
            if (item != null)
            {
                CheckBoxList list = (CheckBoxList)item.FindControl("chkSite");
                if (list != null)
                { 
    
                }
            }
        }
