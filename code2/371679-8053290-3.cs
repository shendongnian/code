    protected void ddlClienti_SelectedIndexChanged(object sender, EventArgs e) 
    { 
        edsContatti.WhereParameters[0].DefaultValue = ((DropDownList)sender).SelectedValue;
        // Call DataBind to reload the DataSource based on the new WHERE clause
        edsContatti.DataBind();
        // Since you're using a DetailsView, you have to find the nested control within it
        DropDownList ddlContatti = (DropDownList)DetailsView1.FindControl("ddlConcatti");
        // And then call DataBind on it as well
        ddlConcatti.DataBind();
    }
