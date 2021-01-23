    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDestination.SelectedIndex > 0)
        {
            string goToWebsite = ddlDestination.SelectedValue;
            Response.Redirect(goToWebsite);
        }
    }
