    protected void grd_ddlEmp_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView row = ((DropDownList)sender).NamingContainer as GridViewRow;
        Label Designation = row.FindControl("id of the designation label") as Label;
        Designation.Text = "new Designation Name";
    }
