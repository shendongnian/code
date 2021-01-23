    protected void yourMethod(object sender, GridViewCommandEventArgs e) {
        if (e.CommandName == "yourButtonName") {
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            TextBox someTextBox = row.FindControl("tb") as TextBox;
            string textValue = someTextBox.Text;
        }
    }
