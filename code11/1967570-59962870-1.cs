    protected void loginButton_Click(object sender, EventArgs e)
    {
        //txtUserName is textbox for inputting user name on login page
        //txtPwd is textbox for inputting password on login page
        bool isValidLogin = Login(txtUserName.Text, txtPwd.Text);
        if (isValidLogin) {
                  Response.Redirect("~/Master.aspx");
        }
    }
