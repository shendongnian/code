    private void btnSubmit_Click(object sender, System.EventArgs e)
    {
    Response.Redirect("Webform2.aspx?Email=" +
    this.txtemail.Text + "&Pwd=" +
    txtPassword.Text);
    } 
