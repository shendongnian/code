    protected void gvsearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select") {
            TextBox1.Text = e.CommandArgument.ToString();
            mdlPopup.Hide();
        }
    }
