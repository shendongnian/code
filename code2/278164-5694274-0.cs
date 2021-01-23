    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextBox txtSomeNewValue = ((TextBox)GridView1.FooterRow.FindControl("txtSomeNewValue"));
        string theTextValue = txtSomeNewValue.Text;
    }
