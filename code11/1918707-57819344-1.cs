    private void Login_Click(object sender, EventArgs e)
            {
                //Check if password is ok
                if(txtPassword.Text == "test")// check the password
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    // show error if password did not match
                }
            }
    
            private void Cancel_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
            }
