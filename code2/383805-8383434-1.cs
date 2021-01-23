    protected void grdUsedCatheters_RowEditing(object sender, GridViewEditEventArgs e)
     {
        try
        {
            Label lblFrom = (Label)grdUsedCatheters.Rows[e.NewEditIndex].FindControl("lblFrom"); //lblFrom is the ID of label
     
            grdUsedCatheters.EditIndex = e.NewEditIndex;
            BindCatheterGrid();
            DropDownList ddlFrom = (DropDownList)grdUsedCatheters.Rows[e.NewEditIndex].FindControl("ddFrom");
            DropDownList ddlTo = (DropDownList)grdUsedCatheters.Rows[e.NewEditIndex].FindControl("ddTo");
            BindDropDowns(ddlFrom);
            BindDropDowns(ddlTo);
            ddlFrom.Text = lblFrom.Text;
    
        }
        catch (Exception ex)
        {
            if (ex.HelpLink == null)
                lblMessage.Text = ex.Message;
            else
                lblMessage.Text = ex.HelpLink;
            lblMessage.CssClass = "ERROR";
        }
    
    }
