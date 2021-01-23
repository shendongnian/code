    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Insert", StringComparison.OrdinalIgnoreCase))
        {
            TextBox txtSomeNewValue = ((TextBox)GridView1.FooterRow.FindControl("txtSomeNewValue"));
            string theTextValue = txtSomeNewValue.Text;
        }
    }
