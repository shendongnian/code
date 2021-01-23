    public AuthenticateUser Result { get; set; }
    private void btnAuthenticate_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text == string.Empty || txtPassword.Text == string.Empty)
        {
            MessageBox.Show("Please fill both information first.");
        }
        else
        {
            // Don't try to call the other window here, just set the result and close...
            Result = new AuthenticateUser();
            Result.UserName = txtUserName.Text;
            Result.Password = txtPassword.Text;
            Close();
        }
     }
