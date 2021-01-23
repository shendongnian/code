        private void btnLogon_Click(object sender, EventArgs e)
        {
            try
            {
                if (Authorize.Invoke(txtUsername.Text, txtPassword.Text, txtPath.Text))
                {
                    this.BackgroundImage = TelefloraDemo.Properties.Resources._189469;
                    this.pnlLogon.Visible = false;
                    MessageBox.Show("You have Logged On!");
                }
            }
            catch (AuthenticationException aex)
            {
                DemoCode.LogException(aex);
                MessageBox.Show(aex.ToString());
            }
            catch (Exception ex)
            {
                DemoCode.LogException(ex);
                MessageBox.Show("No Authenticator");
            }
                       
        }
        public delegate bool Authenticate(string Username,string Password,string Path);
        public event Authenticate Authorize;
