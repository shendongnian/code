    protected void ddlSource_SelectedIndexChanged(object sender, EventArgs e)
    {
    	if ((sender as DropDownList).SelectedValue == "Decimal")
    	{
    		ddlTarget.Items.Remove("Decimal");
    		ddlTarget.DataBind();
    	}
    }
